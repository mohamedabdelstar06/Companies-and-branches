using System.Threading.Tasks;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.Branch;
using ZAD.Application.Interfaces;
using ZAD.WebAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ZAD.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<ActionResult<PageResult<BranchListDto>>> GetAll([FromQuery] PageQuery query)
        {
            return Ok(await _branchService.GetPageAsync(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BranchDetailDto>> GetById(int id)
        {
            return Ok(await _branchService.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<BranchDetailDto>> Create([FromForm] CreateBranchDto dto)
        {
            var result = await _branchService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BranchDetailDto>> Update(int id, [FromForm] UpdateBranchDto dto)
        {
            dto.Id = id;
            return Ok(await _branchService.UpdateAsync(dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _branchService.DeleteAsync(id);
            return Ok(new { message });
        }
    }
}
