using Microsoft.AspNetCore.Mvc;
using DataService.APIProject.DTOs;
using DataService.APIProject.Models;
using DataService.APIProject.Repository;

namespace DataService.APIProject.Controllers
{
    [ApiController]
    [Route("api/Taxes")]
    public class TaxlFeeController : ControllerBase
    {
        private ITaxFeeRepository _taxFeeRepository;

        public TaxlFeeController(ITaxFeeRepository taxFeeRepository)
        {
            _taxFeeRepository = taxFeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CongestionTax>>> Get()
        {
            try
            {
                var list = await _taxFeeRepository.Get();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CongestionTax>> GetById(int id)
        {
            try
            {
                var result = await _taxFeeRepository.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CongestionTax>> Post([FromQuery] TaxFeeDto newFee)
        {
           try
            {
                var model = await _taxFeeRepository.Add(newFee);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                await _taxFeeRepository.Delete(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }
    }
}
