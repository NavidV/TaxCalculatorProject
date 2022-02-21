using Microsoft.AspNetCore.Mvc;
using TaxCalculator.ServicesAPI.Repository;
using TaxCalculatorService.APIProject.Helpers;
using TaxCalculatorService.APIPrpject.Models;

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
        public IActionResult GetTaxFee([FromQuery] Enums.VehiclesEnum vehicle, [FromQuery] DateTime[] dates, Enums.CitiesEnum city)
        {
            try
            {
                var result = _calculator.GetTotalTax(new VehicleType { Vehicle = vehicle}, dates, new SelectedCity { City = city });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
