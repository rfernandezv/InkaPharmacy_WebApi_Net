using InkaPharmacy.Api.Common.Domain.Specification;
using System;
using System.Linq.Expressions;

namespace InkaPharmacy.Api.Product.Infrastructure.Persistence.NHibernate.Specification
{

    public class FindByCategoryBySpecification : Specification<Product>
    {
        private readonly long _Category_id;

        public FindByCategoryBySpecification(long Category_id)
        {
            _Category_id = Category_id;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => (product.Category_id == _Category_id);
        }
    }
}
