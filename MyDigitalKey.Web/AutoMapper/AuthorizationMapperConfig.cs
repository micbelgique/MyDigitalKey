using AutoMapper;
using MyDigitalKey.Domain.Models;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Web.AutoMapper
{
    public class AuthorizationMapperConfig : Profile
    {
        public AuthorizationMapperConfig()
        {
            CreateMap<Authorization, AuthorizationDto>();
        }
    }
}