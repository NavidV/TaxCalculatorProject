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
            SelectedCity city = _mapper.Map<CityDto, SelectedCity>(model);
            
            if (city.Id > 0)
            {
                _dbContext.Cities.Update(city);
            }
            else
            {
                _dbContext.Cities.Add(city);
            }
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<SelectedCity, CityDto>(city);
        }

        public async Task<bool> DeleteCity(int id)
        {
            try
            {
                SelectedCity city = await _dbContext.Cities.FirstAsync(x => x.Id == id);

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
            List<SelectedCity> citys = await _dbContext.Cities.ToListAsync();
            return _mapper.Map<List<CityDto>>(citys);
        }

        public async Task<CityDto> GetCityById(int id)
        {
            SelectedCity city = await _dbContext.Cities.SingleOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CityDto>(city);
        }
    }
}
