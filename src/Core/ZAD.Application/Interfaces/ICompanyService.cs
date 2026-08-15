using System.Threading.Tasks;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.Company;

namespace ZAD.Application.Interfaces
{
    public interface ICompanyService : IAppService
    {
        Task<CompanyDetailDto> CreateAsync(CreateCompanyDto dto);
        Task<CompanyDetailDto> UpdateAsync(UpdateCompanyDto dto);
        Task<string> DeleteAsync(int id);
        Task<CompanyDetailDto> GetAsync(int id);
        Task<PageResult<CompanyListDto>> GetPageAsync(PageQuery query);
        Task ToggleActiveAsync(int id);
    }
}
