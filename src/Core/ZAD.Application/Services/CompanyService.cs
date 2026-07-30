using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.Company;
using ZAD.Application.Exceptions;
using ZAD.Application.Interfaces;
using ZAD.Domain.Entities;
using ZAD.Domain.Interfaces;
using Microsoft.Extensions.Logging;

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

            var company = _mapper.Map<Company>(dto);
            
            int count = _unitOfWork.Companies.FindAllNoTracking().Count();
            company.Code = (count + 1).ToString();

            if (dto.Logo != null)
            {
                company.LogoPath = await _fileUploadService.UploadFileAsync(dto.Logo, "companies");
            }

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

            _mapper.Map(dto, company);

            if (dto.Logo != null)
            {
                company.LogoPath = await _fileUploadService.UploadFileAsync(dto.Logo, "companies");
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
    }
}
