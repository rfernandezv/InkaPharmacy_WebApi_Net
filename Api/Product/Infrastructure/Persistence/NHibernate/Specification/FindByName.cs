using InkaPharmacy.Api.Common.Domain.Specification;
using System;
using System.Linq.Expressions;

namespace InkaPharmacy.Api.Product.Infrastructure.Persistence.NHibernate.Specification
{
    public class FindByNameBySpecification : Specification<Product>
    {
        private readonly string _ProductName;

        public FindByNameBySpecification(string ProductName)
        {
            _ProductName = ProductName;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => (product.Name == _ProductName);
        }
    }
}
