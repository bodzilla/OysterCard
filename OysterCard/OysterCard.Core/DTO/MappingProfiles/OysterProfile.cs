using AutoMapper;
using OysterCard.Core.Models;

namespace OysterCard.Core.DTO.MappingProfiles
{
    /// <inheritdoc />
    public sealed class OysterProfile : Profile
    {
        /// <inheritdoc />
        public OysterProfile() => CreateMap<Oyster, OysterDTO>().ReverseMap();
    }
}
