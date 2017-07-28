using System.Collections.Generic;
using AutoMapper;

namespace MyDigitalKey.Web.AutoMapper
{
    public static class MappingConfig
    {
        public static IEnumerable<Profile> GetProfiles()
        {
            return new List<Profile>()
            {
                new UserMapperConfig(),
                new LockMapperConfig(),
                new AuthorizationMapperConfig()
            };
        }
    }
}