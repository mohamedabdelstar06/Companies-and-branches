using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.VehicleRental.Tenant;
using ZAD.Application.Exceptions;
using ZAD.Application.Interfaces.VehicleRental;
using ZAD.Domain.Entities.VehicleRental.Tenants;
using ZAD.Domain.Interfaces;

namespace ZAD.Application.Services.VehicleRental
{
    public class TenantService : ITenantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<TenantService> _logger;

        public TenantService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TenantService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TenantListDto> CreateAsync(CreateTenantDto dto)
        {
            var tenant = new Tenant(dto.Name, dto.LicenseNumber, dto.PassportNumber, dto.UnifiedNumber, dto.IdNumber, dto.Mobile, dto.Birthday);
            await _unitOfWork.Tenants.AddAsync(tenant);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TenantListDto>(tenant);
        }

        public async Task<string> DeleteAsync(int id)
        {
            await _unitOfWork.Tenants.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return "Tenant deleted successfully.";
        }

        public async Task<IEnumerable<TenantDropdownDto>> GetDropdownAsync()
        {
            var tenants = await _unitOfWork.Tenants.GetAsync(t => !t.IsDeleted);
            return _mapper.Map<IEnumerable<TenantDropdownDto>>(tenants);
        }

        public async Task<PageResult<TenantListDto>> GetPageAsync(PageQuery query)
        {
            var (items, totalCount) = await _unitOfWork.Tenants.GetPageAsync<TenantListDto>(
                query.PageIndex,
                query.PageSize,
                query.SearchTerm,
                query.SortColumn,
                query.SortDirection,
                query.IsActive);

            return new PageResult<TenantListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageIndex = query.PageIndex,
                PageSize = query.PageSize
            };
        }
    }
}
