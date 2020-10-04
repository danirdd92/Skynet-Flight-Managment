using AutoMapper;
using Skynet.Entities.Dtos;
using Skynet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skynet.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Airline, AirlineDto>()
                .ForPath(c => c.Country.CountryName,
                opt => opt.MapFrom(m => m.Country.Name));
            
            CreateMap<Country, CountryDto>()
                .ForMember(m => m.CountryName,
                opt => opt.MapFrom(s => s.Name));
            
            CreateMap<Flight, FlightDto>();
            
            CreateMap<User, UserDto>();

            CreateMap<UserForRegistrationDto, User>();

            CreateMap<UserForAuthenticationDto, User>();
        }
    }
}
