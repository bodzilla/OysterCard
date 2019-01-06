using AutoMapper;
using OysterCard.Core.Mappings.MappingProfiles;

namespace OysterCard.Core.Mappings
{
    public static class MappingConfiguration
    {
        /// <summary>
        /// Wires up all DTO mappings.
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile(new UserProfile());
                config.AddProfile(new OysterProfile());
            });
        }
    }
}
