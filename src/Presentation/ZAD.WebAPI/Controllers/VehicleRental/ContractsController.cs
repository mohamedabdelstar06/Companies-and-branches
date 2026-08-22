using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.VehicleRental.Contract;
using ZAD.Application.Interfaces.VehicleRental;
using ZAD.WebAPI.Filters;

namespace ZAD.WebAPI.Controllers.VehicleRental
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public async Task<ActionResult<PageResult<ContractListDto>>> GetAll([FromQuery] PageQuery query)
        {
            return Ok(await _contractService.GetPageAsync(query));
        }

        [HttpGet("dropdowns")]
        public async Task<ActionResult<ContractDropdownsDto>> GetDropdowns()
        {
            return Ok(await _contractService.GetDropdownsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContractDetailDto>> GetById(int id)
        {
            return Ok(await _contractService.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<ContractDetailDto>> Create([FromBody] CreateContractDto dto)
        {
            var result = await _contractService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ContractDetailDto>> Update(int id, [FromBody] UpdateContractDto dto)
        {
            dto.Id = id;
            return Ok(await _contractService.UpdateAsync(dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _contractService.DeleteAsync(id);
            return Ok(new { message });
        }
    }
}
