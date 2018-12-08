using InkaPharmacy.Api.Common.Domain.Specification;
using System;
using System.Linq.Expressions;

namespace InkaPharmacy.Api.Customers.Infrastructure.Persistence.NHibernate.Specification
{
    public class GetByIdBySpecification : Specification<Customer>
    {
        private readonly long _CustomerId;

        public GetByIdBySpecification(long CustomerId)
        {
            _CustomerId = CustomerId;
        }

        public override Expression<Func<Customer, bool>> ToExpression()
        {
            return customer => (customer.Id == _CustomerId);
        }
    }
}
