using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ZAD.Application.DTOs.Lookups;
using ZAD.Application.Interfaces;
using ZAD.Domain.Interfaces;

namespace ZAD.Application.Services
{
    public class LookupService : ILookupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LookupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<LookupDto>> GetLookupsAsync(string lookupKey, string culture)
        {
            var lookups = await _unitOfWork.Lookups.GetAsync(x => x.LookupKey == lookupKey && x.Culture == culture);

            return lookups.Select(x => new LookupDto
            {
                Id = x.Id,
                Value = x.Value
            });
        }
    }
}
