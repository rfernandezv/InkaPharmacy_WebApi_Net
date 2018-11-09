using AutoMapper;
using InkaPharmacy.Api.Providers.Domain.Entity;
using InkaPharmacy.Api.Providers.Application.Dto;

namespace InkaPharmacy.Api.Providers.Application.Assembler
{
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<Provider, ProviderDto>();
        }
    }
}
