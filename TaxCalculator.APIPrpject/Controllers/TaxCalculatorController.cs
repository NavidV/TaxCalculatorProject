using Microsoft.AspNetCore.Mvc;
using TaxCalculator.ServicesAPI.Repository;
using TaxCalculatorService.APIPrpject.Models;
using static TaxCalculatorService.APIProject.Helpers.Enums;

namespace TaxCalculatorService.APIPrpject.Controllers
{
    [ApiController]
    [Route("api/TaxCalculator")]
    public class TaxCalculatorController : ControllerBase
    {
        private ITaxCalculatorRepository _calculator;

        public TaxCalculatorController(ITaxCalculatorRepository calculator)
        {
            _calculator = calculator;
        }
        [HttpGet]
        public object GetTaxFee([FromQuery] VehiclesEnum vehicle, [FromQuery] DateTime[] dates, CitiesEnum city)
        {
            try
            {
                var result = _calculator.GetTotalTax(new VehicleType { Name = vehicle.ToString() }, dates, city.ToString());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
