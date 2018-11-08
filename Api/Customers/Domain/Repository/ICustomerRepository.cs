using InkaPhatmacy.Api.Common.Domain.Specification;
using System.Collections.Generic;

namespace InkaPhatmacy.Api.Customers.Domain.Repository
{
    public interface ICustomerRepository
    {
        Customer FindByDocumentNumber( Specification<Customer> specification);

    }
}
