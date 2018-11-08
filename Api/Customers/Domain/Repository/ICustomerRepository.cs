using EnterprisePatterns.Api.Common.Domain.Specification;
using System.Collections.Generic;

namespace EnterprisePatterns.Api.Customers.Domain.Repository
{
    public interface ICustomerRepository
    {
        Customer FindByDocumentNumber( Specification<Customer> specification);

    }
}
