using AutoMapper;
using InkaPharmacy.Api.Providers.Application.Dto;
using InkaPharmacy.Api.Providers.Domain.Entity;

namespace InkaPharmacy.Api.Providers.Application.Assembler
{


    public class ProviderAssembler
    {
        private readonly IMapper _mapper;

        public ProviderAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Provider ToEntity(ProviderDto providerDto)
        {
            return _mapper.Map<Provider>(providerDto);
        }

        public ProviderDto FromProviderToProviderDto(Provider provider)
        {
            return _mapper.Map<Provider, ProviderDto>(provider);
        }
    }

}
