using Microsoft.AspNetCore.Mvc;
using DataService.APIProject.DTOs;
using DataService.APIProject.Repository;

namespace DataService.APIProject.Controllers
{
    [ApiController]
    [Route("api/Cities")]
    public class CityController : Controller
    {
        protected ResponseDto _response;
        private ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<CityDto> cityDtos = await _cityRepository.GetCities();
                _response.Result = cityDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccessfull = false;
                _response.ErrorMessages
                    = new List<string>() { ex.Message.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                CityDto cityDto = await _cityRepository.GetCityById(id);
                _response.Result = cityDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccessfull = false;
                _response.ErrorMessages
                    = new List<string>() { ex.Message.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromQuery] CityDto newCost)
        {
            try
            {
                var model = await _cityRepository.AddUpdateCity(newCost);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccessfull = false;
                _response.ErrorMessages
                    = new List<string>() { ex.Message.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                _response.IsSuccessfull = await _cityRepository.DeleteCity(id);
            }
            catch (Exception ex)
            {
                _response.IsSuccessfull = false;
                _response.ErrorMessages
                    = new List<string>() { ex.Message.ToString() };
            }
            return _response;
        }
    }
}
