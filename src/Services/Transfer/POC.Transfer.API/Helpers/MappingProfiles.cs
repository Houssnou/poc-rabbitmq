using AutoMapper;
using POC.Transfer.API.Dtos;

namespace POC.Transfer.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Core.Entities.Transfer, TransfertDto>();
        }
    }
}
