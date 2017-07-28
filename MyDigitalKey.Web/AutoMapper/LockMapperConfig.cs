using AutoMapper;
using MyDigitalKey.Domain.Models;
using MyDigitalKey.Services.Contracts.Models;

namespace MyDigitalKey.Web.AutoMapper
{
    public class LockMapperConfig : Profile
    {
        public LockMapperConfig()
        {
            CreateMap<Lock, LockDto>();
        }
    }
}