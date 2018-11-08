    using InkaPhatmacy.Api.Common.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InkaPhatmacy.Api.Product.Infrastructure.Persistence.NHibernate.Specification
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
            return customer => (customer.Name == _ProductName);
        }
    }
}
