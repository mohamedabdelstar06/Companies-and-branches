using System.Threading.Tasks;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.Company;
using ZAD.Application.Interfaces;
using ZAD.WebAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ZAD.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<PageResult<CompanyListDto>>> GetAll([FromQuery] PageQuery query)
        {
            return Ok(await _companyService.GetPageAsync(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDetailDto>> GetById(int id)
        {
            return Ok(await _companyService.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDetailDto>> Create([FromForm] CreateCompanyDto dto)
        {
            var result = await _companyService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyDetailDto>> Update(int id, [FromForm] UpdateCompanyDto dto)
        {
            dto.Id = id;
            return Ok(await _companyService.UpdateAsync(dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _companyService.DeleteAsync(id);
            return Ok(new { message });
        }
    }
}
