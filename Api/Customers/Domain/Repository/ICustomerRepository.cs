using InkaPharmacy.Api.Common.Domain.Specification;
using System.Collections.Generic;

namespace InkaPharmacy.Api.Customers.Domain.Repository
{
    public interface ICustomerRepository
    {
        Customer FindByDocumentNumber( Specification<Customer> specification);

    }
}
