using DataService.APIProject.DTOs;

namespace DataService.APIProject.Repository
{
    public interface ICityRepository
    {
        Task<CityDto> AddUpdateCity(CityDto model);
        Task<IEnumerable<CityDto>> GetCities();
        Task<CityDto> GetCityById(int id); 
        Task<bool> DeleteCity(int id);
    }
}