using AutoMapper;
using World.Api.DTO.Country;
using World.Api.DTO.State;
using World.Api.Modals;

namespace World.Api.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            //source destination
            //CreateMap<CreateCountryDto, Country>();
            CreateMap<Country, GetCountriesDto>().ReverseMap();
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountriesDto>().ReverseMap();
            CreateMap<States, GetStateDto>().ReverseMap();
            CreateMap<States, CreateStateDto>().ReverseMap();
            CreateMap<States, UpdateStateDto>().ReverseMap();
        }
    }
}
