using System.Collections.Generic;
using System.Threading.Tasks;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.VehicleRental.Tenant;
using ZAD.Application.Interfaces;

namespace ZAD.Application.Interfaces.VehicleRental
{
    public interface ITenantService : IAppService
    {
        Task<TenantListDto> CreateAsync(CreateTenantDto dto);
        Task<string> DeleteAsync(int id);
        Task<PageResult<TenantListDto>> GetPageAsync(PageQuery query);
        Task<IEnumerable<TenantDropdownDto>> GetDropdownAsync();
    }
}
