using AutoMapper;
using DigitalArs_copia.DTO_s;
using DigitalArs_copia.Entities;

namespace DigitalArs_copia.Mapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile() 
        {
            CreateMap<Account, AccountDTO>();

            CreateMap<AccountDTO, Account>()
            .ForMember(dest => dest.IsBlocked, opt => opt.MapFrom(src => false));

        
        }
    }
}
