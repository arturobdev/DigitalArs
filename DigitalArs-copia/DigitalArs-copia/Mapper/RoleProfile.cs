using AutoMapper;
using DigitalArs_copia.DTO_s;
using DigitalArs_copia.Entities;

namespace DigitalArs_copia.Mapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDTO, Role>();

            CreateMap<Role, RoleDTO>();

            CreateMap<Role, Role>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
