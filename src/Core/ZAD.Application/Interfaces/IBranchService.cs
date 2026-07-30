using System.Threading.Tasks;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.Branch;

namespace ZAD.Application.Interfaces
{
    public interface IBranchService : IAppService
    {
        Task<BranchDetailDto> CreateAsync(CreateBranchDto dto);
        Task<BranchDetailDto> UpdateAsync(UpdateBranchDto dto);
        Task<string> DeleteAsync(int id);
        Task<BranchDetailDto> GetAsync(int id);
        Task<PageResult<BranchListDto>> GetPageAsync(PageQuery query);
    }
}
