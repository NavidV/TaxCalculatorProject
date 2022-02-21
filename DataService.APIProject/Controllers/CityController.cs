using Microsoft.AspNetCore.Mvc;
using DataService.APIProject.DTOs;
using DataService.APIProject.Repository;

namespace DataService.APIProject.Controllers
{
    [ApiController]
    [Route("api/Cities")]
    public class CityController : Controller
    {
        private ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<CityDto> cityDtos = await _cityRepository.GetCities();
                return Ok(cityDtos);

            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 500 };
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                CityDto cityDto = await _cityRepository.GetCityById(id);
                if (cityDto == null)
                    return NotFound();
                return Ok(cityDto);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 500 };
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] CityDto newCost)
        {
            try
            {
                var model = await _cityRepository.AddUpdateCity(newCost);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 500 };
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _cityRepository.DeleteCity(id));
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
