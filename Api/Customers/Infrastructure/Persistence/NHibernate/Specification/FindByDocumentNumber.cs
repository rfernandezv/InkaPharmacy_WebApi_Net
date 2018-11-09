using InkaPharmacy.Api.Common.Domain.Specification;
using System;
using System.Linq.Expressions;

namespace InkaPharmacy.Api.Customers.Infrastructure.Persistence.NHibernate.Specification
{
    public class FindByDocumentNumberBySpecification : Specification<Customer>
    {
        private readonly string _DocumentNumber;

        public FindByDocumentNumberBySpecification(string DocumentNumber )
        {
            _DocumentNumber = DocumentNumber;
        }

        public override Expression<Func<Customer, bool>> ToExpression()
        {
            return customer => (customer.Document_Number ==  _DocumentNumber);
        }
    }
}
