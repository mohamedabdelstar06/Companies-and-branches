using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.Company;
using ZAD.Application.Exceptions;
using ZAD.Application.Interfaces;
using ZAD.Domain.Entities.Common;
using ZAD.Domain.Entities.Companies;
using ZAD.Domain.Events;
using ZAD.Domain.Interfaces;
using ZAD.Domain.ValueObjects;

namespace ZAD.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyService> _logger;
        private readonly IFileUploadService _fileUploadService;

        public CompanyService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ILogger<CompanyService> logger, 
            IFileUploadService fileUploadService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _fileUploadService = fileUploadService;
        }

        public async Task<CompanyDetailDto> CreateAsync(CreateCompanyDto dto)
        {
            _logger.LogInformation("Creating new Company with NameEn: {NameEn}", dto.NameEn);

            if (_unitOfWork.Companies.FindAllNoTracking().Any(c => c.NameEn == dto.NameEn))
            {
                _logger.LogWarning("Company with NameEn {NameEn} already exists", dto.NameEn);
                throw new EntityDuplicatedException($"Company with NameEn '{dto.NameEn}' already exists.");
            }

            var address = new Address(dto.Country, dto.City, dto.AddressAr, dto.AddressEn);
            
            int count = _unitOfWork.Companies.FindAllNoTracking().Count();
            string code = string.IsNullOrWhiteSpace(dto.Code) ? (count + 1).ToString() : dto.Code;

            string? logoPath = null;
            if (dto.Logo != null)
            {
                logoPath = await _fileUploadService.UploadFileAsync(dto.Logo, "companies");
            }

            var company = new Company(code, dto.NameAr, dto.NameEn, address, dto.Nationality, dto.Language, logoPath);

            if (dto.Contacts != null)
            {
                foreach (var contactDto in dto.Contacts)
                {
                    company.AddContact(new Contact(contactDto.Type, contactDto.Value, contactDto.Name));
                }
            }

            if (dto.Documents != null)
            {
                foreach (var docDto in dto.Documents)
                {
                    string? docPath = docDto.AttachFile != null ? await _fileUploadService.UploadFileAsync(docDto.AttachFile, "documents") : null;
                    company.AddDocument(new Document(docDto.Type, docDto.DocumentNumber, docPath ?? "", docDto.ExpiryDate));
                }
            }

            company.AddDomainEvent(new CompanyCreatedEvent(company.Id));

            await _unitOfWork.Companies.AddAsync(company);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Company {Code} created successfully", company.Code);

            return _mapper.Map<CompanyDetailDto>(company);
        }

        public async Task<CompanyDetailDto> UpdateAsync(UpdateCompanyDto dto)
        {
            _logger.LogInformation("Updating Company {Id}", dto.Id);

            var company = await _unitOfWork.Companies.GetByIdAsync(dto.Id);
            if (company == null)
            {
                _logger.LogWarning("Company {Id} not found", dto.Id);
                throw new NotFoundException($"Company {dto.Id} not found.");
            }

            if (_unitOfWork.Companies.FindAllNoTracking().Any(c => c.NameEn == dto.NameEn && c.Id != dto.Id))
            {
                _logger.LogWarning("Company with NameEn {NameEn} already exists", dto.NameEn);
                throw new EntityDuplicatedException($"Company with NameEn '{dto.NameEn}' already exists.");
            }

            var address = new Address(dto.Country, dto.City, dto.AddressAr, dto.AddressEn);

            string? logoPath = null;
            if (dto.Logo != null)
            {
                logoPath = await _fileUploadService.UploadFileAsync(dto.Logo, "companies");
            }

            company.Update(dto.NameAr, dto.NameEn, address, dto.Nationality, dto.Language, logoPath, dto.IsActive);

            company.ClearContacts();
            if (dto.Contacts != null)
            {
                foreach (var contactDto in dto.Contacts)
                {
                    company.AddContact(new Contact(contactDto.Type, contactDto.Value, contactDto.Name));
                }
            }

            company.ClearDocuments();
            if (dto.Documents != null)
            {
                foreach (var docDto in dto.Documents)
                {
                    string? docPath = docDto.AttachFile != null ? await _fileUploadService.UploadFileAsync(docDto.AttachFile, "documents") : null;
                    company.AddDocument(new Document(docDto.Type, docDto.DocumentNumber, docPath ?? "", docDto.ExpiryDate));
                }
            }

            _unitOfWork.Companies.Update(company);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Company {Id} updated successfully", company.Id);

            return _mapper.Map<CompanyDetailDto>(company);
        }

        public async Task<string> DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting Company {Id}", id);

            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if (company == null)
            {
                _logger.LogWarning("Company {Id} not found for deletion", id);
                throw new NotFoundException($"Company {id} not found.");
            }

            string companyName = !string.IsNullOrEmpty(company.NameEn) ? company.NameEn : company.NameAr;

            await _unitOfWork.Companies.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Company {Id} deleted successfully", id);

            return $"Company '{companyName}' with ID {id} has been deleted successfully.";
        }

        public async Task<CompanyDetailDto> GetAsync(int id)
        {
            _logger.LogInformation("Getting Company {Id}", id);

            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if (company == null)
            {
                _logger.LogWarning("Company {Id} not found", id);
                throw new NotFoundException($"Company {id} not found.");
            }

            return _mapper.Map<CompanyDetailDto>(company);
        }

        public async Task<PageResult<CompanyListDto>> GetPageAsync(PageQuery query)
        {
            _logger.LogInformation("Getting Company page {PageIndex}", query.PageIndex);

            var (items, totalCount) = await _unitOfWork.Companies.GetPageAsync<CompanyListDto>(
                query.PageIndex,
                query.PageSize,
                query.SearchTerm,
                query.SortColumn,
                query.SortDirection,
                query.IsActive);

            return new PageResult<CompanyListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageIndex = query.PageIndex,
                PageSize = query.PageSize
            };
        }

        public async Task ToggleActiveAsync(int id)
        {
            _logger.LogInformation("Toggling active status for Company {Id}", id);

            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if (company == null)
            {
                _logger.LogWarning("Company {Id} not found", id);
                throw new NotFoundException($"Company {id} not found.");
            }

            company.Update(
                company.NameAr, 
                company.NameEn, 
                company.Address, 
                company.Nationality, 
                company.Language, 
                company.LogoPath, 
                !company.IsActive);

            _unitOfWork.Companies.Update(company);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Company {Id} active status toggled successfully", id);
        }
    }
}
