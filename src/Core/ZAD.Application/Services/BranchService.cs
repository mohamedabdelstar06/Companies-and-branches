using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.Branch;
using ZAD.Application.Exceptions;
using ZAD.Application.Interfaces;
using ZAD.Domain.Entities.Common;
using ZAD.Domain.Entities.Branches;
using ZAD.Domain.Events;
using ZAD.Domain.Interfaces;
using ZAD.Domain.ValueObjects;

namespace ZAD.Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<BranchService> _logger;
        private readonly IFileUploadService _fileUploadService;

        public BranchService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ILogger<BranchService> logger, 
            IFileUploadService fileUploadService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _fileUploadService = fileUploadService;
        }

        public async Task<BranchDetailDto> CreateAsync(CreateBranchDto dto)
        {
            _logger.LogInformation("Creating new Branch with NameEn: {NameEn}", dto.NameEn);

            if (_unitOfWork.Branches.FindAllNoTracking().Any(b => b.NameEn == dto.NameEn && b.CompanyId == dto.CompanyId))
            {
                _logger.LogWarning("Branch with NameEn {NameEn} already exists in Company {CompanyId}", dto.NameEn, dto.CompanyId);
                throw new EntityDuplicatedException($"Branch with NameEn '{dto.NameEn}' already exists in this Company.");
            }

            var address = new Address(dto.Country, dto.City, dto.AddressAr, dto.AddressEn);

            int count = _unitOfWork.Branches.FindAllNoTracking().Count();
            string code = string.IsNullOrWhiteSpace(dto.Code) ? (count + 1).ToString() : dto.Code;

            string? logoPath = null;
            if (dto.Logo != null)
            {
                logoPath = await _fileUploadService.UploadFileAsync(dto.Logo, "branches");
            }

            var branch = new Branch(code, dto.NameAr, dto.NameEn, dto.CompanyId, address, dto.CostCenter, dto.IsMainBranch, logoPath);

            if (dto.Contacts != null)
            {
                foreach (var contactDto in dto.Contacts)
                {
                    branch.AddContact(new Contact(contactDto.Type, contactDto.Value, contactDto.Name));
                }
            }

            if (dto.Documents != null)
            {
                foreach (var docDto in dto.Documents)
                {
                    string? docPath = docDto.AttachFile != null ? await _fileUploadService.UploadFileAsync(docDto.AttachFile, "documents") : null;
                    branch.AddDocument(new Document(docDto.Type, docDto.DocumentNumber, docPath ?? "", docDto.ExpiryDate));
                }
            }

            branch.AddDomainEvent(new BranchCreatedEvent(branch.Id));

            await _unitOfWork.Branches.AddAsync(branch);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Branch {Code} created successfully", branch.Code);

            return _mapper.Map<BranchDetailDto>(branch);
        }

        public async Task<BranchDetailDto> UpdateAsync(UpdateBranchDto dto)
        {
            _logger.LogInformation("Updating Branch {Id}", dto.Id);

            var branch = await _unitOfWork.Branches.GetByIdAsync(dto.Id);
            if (branch == null)
            {
                _logger.LogWarning("Branch {Id} not found", dto.Id);
                throw new NotFoundException($"Branch {dto.Id} not found.");
            }

            if (_unitOfWork.Branches.FindAllNoTracking().Any(b => b.NameEn == dto.NameEn && b.CompanyId == dto.CompanyId && b.Id != dto.Id))
            {
                _logger.LogWarning("Branch with NameEn {NameEn} already exists in Company {CompanyId}", dto.NameEn, dto.CompanyId);
                throw new EntityDuplicatedException($"Branch with NameEn '{dto.NameEn}' already exists in this Company.");
            }

            var address = new Address(dto.Country, dto.City, dto.AddressAr, dto.AddressEn);

            string? logoPath = null;
            if (dto.Logo != null)
            {
                logoPath = await _fileUploadService.UploadFileAsync(dto.Logo, "branches");
            }

            branch.Update(dto.NameAr, dto.NameEn, dto.CompanyId, address, dto.CostCenter, dto.IsMainBranch, logoPath, dto.IsActive);

            branch.ClearContacts();
            if (dto.Contacts != null)
            {
                foreach (var contactDto in dto.Contacts)
                {
                    branch.AddContact(new Contact(contactDto.Type, contactDto.Value, contactDto.Name));
                }
            }

            branch.ClearDocuments();
            if (dto.Documents != null)
            {
                foreach (var docDto in dto.Documents)
                {
                    string? docPath = docDto.AttachFile != null ? await _fileUploadService.UploadFileAsync(docDto.AttachFile, "documents") : null;
                    branch.AddDocument(new Document(docDto.Type, docDto.DocumentNumber, docPath ?? "", docDto.ExpiryDate));
                }
            }

            _unitOfWork.Branches.Update(branch);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Branch {Id} updated successfully", branch.Id);

            return _mapper.Map<BranchDetailDto>(branch);
        }

        public async Task<string> DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting Branch {Id}", id);

            var branch = await _unitOfWork.Branches.GetByIdAsync(id);
            if (branch == null)
            {
                _logger.LogWarning("Branch {Id} not found for deletion", id);
                throw new NotFoundException($"Branch {id} not found.");
            }

            string branchName = !string.IsNullOrEmpty(branch.NameEn) ? branch.NameEn : branch.NameAr;

            await _unitOfWork.Branches.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Branch {Id} deleted successfully", id);

            return $"Branch '{branchName}' with ID {id} has been deleted successfully.";
        }

        public async Task<BranchDetailDto> GetAsync(int id)
        {
            _logger.LogInformation("Getting Branch {Id}", id);

            var branch = await _unitOfWork.Branches.GetByIdAsync(id);   
            if (branch == null)
            {
                _logger.LogWarning("Branch {Id} not found", id);
                throw new NotFoundException($"Branch {id} not found.");
            }

            return _mapper.Map<BranchDetailDto>(branch);
        }

        public async Task<PageResult<BranchListDto>> GetPageAsync(PageQuery query)
        {
            _logger.LogInformation("Getting Branch page {PageIndex}", query.PageIndex);

            var (items, totalCount) = await _unitOfWork.Branches.GetPageAsync<BranchListDto>(
                query.PageIndex,
                query.PageSize,
                query.SearchTerm,
                query.SortColumn,
                query.SortDirection,
                query.IsActive);

            return new PageResult<BranchListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageIndex = query.PageIndex,
                PageSize = query.PageSize
            };
        }

        public async Task ToggleActiveAsync(int id)
        {
            _logger.LogInformation("Toggling active status for Branch {Id}", id);

            var branch = await _unitOfWork.Branches.GetByIdAsync(id);
            if (branch == null)
            {
                _logger.LogWarning("Branch {Id} not found", id);
                throw new NotFoundException($"Branch {id} not found.");
            }

            branch.Update(
                branch.NameAr, 
                branch.NameEn, 
                branch.CompanyId,
                branch.Address, 
                branch.CostCenter, 
                branch.IsMainBranch, 
                branch.LogoPath, 
                !branch.IsActive);

            _unitOfWork.Branches.Update(branch);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Branch {Id} active status toggled successfully", id);
        }
    }
}
