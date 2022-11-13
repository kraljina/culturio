using AutoMapper;
using Span.Culturio.Api.Data.Entities;
using Span.Culturio.Api.Models.User;

namespace Span.Culturio.Api.Profiles {
    public class UserProfile : Profile {
        public UserProfile() {
            CreateMap<Data.Entities.User, Models.User.UserDto>();
            CreateMap<RegisterUserDto, User>();
        }

    }
}
