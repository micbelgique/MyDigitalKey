using AutoMapper;
using MyDigitalKey.Domain.Models;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Web.AutoMapper
{
    public class UserMapperConfig : Profile
    {
        public UserMapperConfig()
        {
            CreateMap<User, UserDto>();
            CreateMap<DigitalKey, DigitalKeyDto>();
        }
    }
}