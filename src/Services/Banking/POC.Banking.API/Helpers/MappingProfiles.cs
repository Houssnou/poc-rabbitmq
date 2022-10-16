using AutoMapper;
using POC.Banking.API.Dtos.Account;
using POC.Banking.Core.Entities;

namespace POC.Banking.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Account, AccountDto>();
        }
    }
}
