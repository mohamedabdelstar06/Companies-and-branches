using System.Collections.Generic;
using System.Threading.Tasks;
using ZAD.Application.DTOs.Lookups;

namespace ZAD.Application.Interfaces
{
    public interface ILookupService : IAppService
    {
        Task<IEnumerable<LookupDto>> GetLookupsAsync(string lookupKey, string culture);
    }
}
