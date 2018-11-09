using System.Collections.Generic;
using InkaPharmacy.Api.Common.Domain.Specification;
using InkaPharmacy.Api.Providers.Domain.Entity;

namespace InkaPharmacy.Api.Providers.Domain.Repository
{
    public interface IProviderRepository
    {
        List<Provider> GetList(
            Specification<Provider> specification,
            int page = 0,
            int pageSize = 5);

        Provider FindByAnySpecificField(Specification<Provider> specification);
    }

}
