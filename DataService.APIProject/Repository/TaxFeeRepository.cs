using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DataService.APIProject.DbContexts;
using DataService.APIProject.DTOs;
using DataService.APIProject.Models;

namespace DataService.APIProject.Repository
{
    public class TaxFeeRepository : ITaxFeeRepository
    {
        private ApplicationDbContext _dbContext;
        private IMapper _mapper;

        public TaxFeeRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<TaxFeeDto> Add(TaxFeeDto newFee)
        {
            CongestionTax fee = _mapper.Map<TaxFeeDto, CongestionTax>(newFee);

            _dbContext.TaxFees.Add(fee);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CongestionTax, TaxFeeDto>(fee);
        }
        public async Task Delete(int id)
        {
            var fee = await _dbContext.TaxFees.FirstAsync(x => x.Id == id);
            _dbContext.TaxFees.Remove(fee);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<TaxFeeDto>> Get()
        {
            List<CongestionTax> fees = await _dbContext.TaxFees.ToListAsync();
            return _mapper.Map<List<TaxFeeDto>>(fees);
        }
        public async Task<TaxFeeDto> Get(int id)
        {
            CongestionTax fee = await _dbContext.TaxFees.SingleOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<TaxFeeDto>(fee);
        }

    }
}
