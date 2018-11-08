using InkaPharmacy.Api.Common.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
