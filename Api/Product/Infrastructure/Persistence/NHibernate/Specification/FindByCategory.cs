    using InkaPhatmacy.Api.Common.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InkaPhatmacy.Api.Product.Infrastructure.Persistence.NHibernate.Specification
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
            return customer => (customer.Category_id == _Category_id);
        }
    }
}
