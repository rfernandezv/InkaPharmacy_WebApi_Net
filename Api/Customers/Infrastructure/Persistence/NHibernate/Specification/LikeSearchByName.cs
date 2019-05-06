using InkaPharmacy.Api.Common.Domain.Specification;
using System;
using System.Linq.Expressions;

namespace InkaPharmacy.Api.Customers.Infrastructure.Persistence.NHibernate.Specification
{
    public class LikeSearchByNameSpecification : Specification<Customer>
    {
        private readonly string _Name;

        public LikeSearchByNameSpecification(string Name)
        {
            _Name = Name;
        }

        public override Expression<Func<Customer, bool>> ToExpression()
        {
            return customer => (customer.Name.Contains(_Name) || customer.Last_Name1.Contains(_Name) || customer.Last_Name2.Contains(_Name));
        }
    }
}
