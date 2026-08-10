using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZAD.Application.DTOs.Lookups;
using ZAD.Application.Interfaces;

namespace ZAD.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupsController : ControllerBase
    {
        private readonly ILookupService _lookupService;

        public LookupsController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet("{lookupKey}")]
        public async Task<ActionResult<IEnumerable<LookupDto>>> Get(string lookupKey, [FromQuery] string culture = "ar")
        {
            var lookups = await _lookupService.GetLookupsAsync(lookupKey, culture);
            return Ok(lookups);
        }
    }
}
