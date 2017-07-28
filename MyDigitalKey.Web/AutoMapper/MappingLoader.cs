using System.Collections.Generic;
using AutoMapper;

namespace MyDigitalKey.Web.AutoMapper
{
    public static class MappingLoader
    {
        public static MapperConfiguration Config { get; private set; }

        public static IMapper Load()
        {
            var profiles = new List<Profile>();

            profiles.AddRange(MappingConfig.GetProfiles());

            Config = new MapperConfiguration(c =>
            {
                foreach (var profile in profiles)
                    c.AddProfile(profile);
            });

            return Config.CreateMapper();
        }
    }
}