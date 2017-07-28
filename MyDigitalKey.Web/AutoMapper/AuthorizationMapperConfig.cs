using AutoMapper;
using MyDigitalKey.Domain.Models;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Web.AutoMapper
{
    public class AuthorizationMapperConfig : Profile
    {
        public AuthorizationMapperConfig()
        {
            CreateMap<Authorization, AuthorizationDto>()
                .ForMember(m => m.Lock, opt => opt.ResolveUsing(res => new LockDto
                {
                    Id = res.LockId
                }))
                .ForMember(m => m.User, opt => opt.ResolveUsing(res => new UserDto
                {
                    Key = new DigitalKeyDto
                    {
                        Id = res.DigitalKeyId
                    }
                }));
        }
    }
}