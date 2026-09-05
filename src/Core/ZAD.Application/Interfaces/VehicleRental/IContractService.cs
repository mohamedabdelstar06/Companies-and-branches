using System.Threading.Tasks;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.VehicleRental.Contract;
using ZAD.Application.Interfaces;

namespace ZAD.Application.Interfaces.VehicleRental
{
    public interface IContractService : IAppService
    {
        Task<ContractDetailDto> CreateAsync(CreateContractDto dto);
        Task<ContractDetailDto> UpdateAsync(UpdateContractDto dto);
        Task<string> DeleteAsync(int id);
        Task<string> RestoreAsync(int id);
        Task<ContractDetailDto> ConfirmAsync(int id);
        Task<ContractDetailDto> UnconfirmAsync(int id);
        Task<ContractDetailDto> ReceiveVehicleAsync(int id, ReceiveVehicleDto dto);
        Task<ContractDetailDto> ConfirmReceiveVehicleAsync(int id);
        Task<ContractDetailDto> UnreceiveVehicleAsync(int id);
        Task<ContractDetailDto> GetAsync(int id);
        Task<PageResult<ContractListDto>> GetPageAsync(PageQuery query);
        Task<ContractDropdownsDto> GetDropdownsAsync();
    }
}
