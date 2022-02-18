using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DataService.APIProject.DbContexts;
using DataService.APIProject.DTOs;
using DataService.APIProject.Models;

namespace DataService.APIProject.Repository
{
    public class CityRepository : ICityRepository
    {
        private ApplicationDbContext _dbContext;
        private IMapper _mapper;
        public CityRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CityDto> AddUpdateCity(CityDto model)
        {
            City city = _mapper.Map<CityDto, City>(model);
            
            if (city.Id > 0)
            {
                _dbContext.Cities.Update(city);
            }
            else
            {
                _dbContext.Cities.Add(city);
            }
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<City, CityDto>(city);
        }

        public async Task<bool> DeleteCity(int id)
        {
            try
            {
                City city = await _dbContext.Cities.FirstAsync(x => x.Id == id);

                if (city == null)
                    return false;

                _dbContext.Cities.Remove(city);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<CityDto>> GetCities()
        {
            List<City> citys = await _dbContext.Cities.ToListAsync();
            return _mapper.Map<List<CityDto>>(citys);
        }

        public async Task<CityDto> GetCityById(int id)
        {
            City city = await _dbContext.Cities.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CityDto>(city);
        }
    }
}
