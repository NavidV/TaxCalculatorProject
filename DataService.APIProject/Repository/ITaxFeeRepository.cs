using DataService.APIProject.DTOs;

namespace DataService.APIProject.Repository
{
    public interface ITaxFeeRepository
    {
        Task<IEnumerable<TaxFeeDto>> Get();
        Task<TaxFeeDto> Get(int id);
        Task<TaxFeeDto> Add(TaxFeeDto newFee);
        Task Delete(int id);
    }
}
