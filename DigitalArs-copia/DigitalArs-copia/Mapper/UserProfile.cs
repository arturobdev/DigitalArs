using AutoMapper;
using DigitalArs_copia.DTO_s;
using DigitalArs_copia.Entities;

namespace DigitalArs_copia.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile() {

         CreateMap<UserDTO, User>();

         CreateMap<User, UserDTO>();

         CreateMap<UserRegisterDTO, User>();

         CreateMap<User, User>()
        .ForMember(dest => dest.Id, opt => opt.Ignore());
         }
    }
}
