using AutoMapper;
using DataService.APIProject.DTOs;
using DataService.APIProject.Models;

namespace DataService.APIProject
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CongestionTax, TaxFeeDto>();
            CreateMap<TaxFeeDto, CongestionTax>();
            CreateMap<SelectedCity, CityDto>();
            CreateMap<CityDto, SelectedCity>();
        }
    }
}