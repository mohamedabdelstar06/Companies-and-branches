using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.Branch;
using ZAD.Application.Exceptions;
using ZAD.Application.Interfaces;
using ZAD.Domain.Entities;
using ZAD.Domain.Interfaces;
using Microsoft.Extensions.Logging;

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
            _logger.LogInformation("Creating new Branch with NameEn: {NameEn} for Company {CompanyId}", dto.NameEn, dto.CompanyId);

            var company = await _unitOfWork.Companies.GetByIdAsync(dto.CompanyId);
            if (company == null)
            {
                _logger.LogWarning("Company {CompanyId} not found", dto.CompanyId);
                throw new NotFoundException($"Company {dto.CompanyId} not found.");
            }

            if (_unitOfWork.Branches.FindAllNoTracking().Any(b => b.NameEn == dto.NameEn && b.CompanyId == dto.CompanyId))
            {
                _logger.LogWarning("Branch with NameEn {NameEn} already exists in Company {CompanyId}", dto.NameEn, dto.CompanyId);
                throw new EntityDuplicatedException($"Branch with NameEn '{dto.NameEn}' already exists in this Company.");
            }
            var branch = _mapper.Map<Branch>(dto);
            int count = _unitOfWork.Branches.FindAllNoTracking().Count();
            branch.Code = (count + 1).ToString();

            if (dto.Logo != null)
            {
                branch.LogoPath = await _fileUploadService.UploadFileAsync(dto.Logo, "branches");
            }

            await _unitOfWork.Branches.AddAsync(branch);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Branch {Code} created successfully", branch.Code);

            return await GetAsync(branch.Id);
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

            if (branch.CompanyId != dto.CompanyId)
            {
                var company = await _unitOfWork.Companies.GetByIdAsync(dto.CompanyId);
                if (company == null)
                {
                    _logger.LogWarning("Company {CompanyId} not found", dto.CompanyId);
                    throw new NotFoundException($"Company {dto.CompanyId} not found.");
                }
            }

            if (_unitOfWork.Branches.FindAllNoTracking().Any(b => b.NameEn == dto.NameEn && b.CompanyId == dto.CompanyId && b.Id != dto.Id))
            {
                _logger.LogWarning("Branch with NameEn {NameEn} already exists in Company {CompanyId}", dto.NameEn, dto.CompanyId);
                throw new EntityDuplicatedException($"Branch with NameEn '{dto.NameEn}' already exists in this Company.");
            }

            _mapper.Map(dto, branch);

            if (dto.Logo != null)
            {
                branch.LogoPath = await _fileUploadService.UploadFileAsync(dto.Logo, "branches");
            }

            _unitOfWork.Branches.Update(branch);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Branch {Id} updated successfully", branch.Id);

            return await GetAsync(branch.Id);
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
    }
}
