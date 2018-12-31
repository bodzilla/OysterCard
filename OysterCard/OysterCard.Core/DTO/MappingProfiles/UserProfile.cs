using AutoMapper;
using OysterCard.Core.Models;

namespace OysterCard.Core.DTO.MappingProfiles
{
    /// <inheritdoc />
    public sealed class UserProfile : Profile
    {
        /// <inheritdoc />
        public UserProfile() => CreateMap<User, UserDTO>().ReverseMap();
    }
}
