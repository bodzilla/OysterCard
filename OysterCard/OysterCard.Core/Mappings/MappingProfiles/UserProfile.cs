using AutoMapper;
using OysterCard.Core.DTO;
using OysterCard.Core.Models;

namespace OysterCard.Core.Mappings.MappingProfiles
{
    /// <inheritdoc />
    public sealed class UserProfile : Profile
    {
        /// <inheritdoc />
        public UserProfile() => CreateMap<User, UserDTO>().ReverseMap();
    }
}
