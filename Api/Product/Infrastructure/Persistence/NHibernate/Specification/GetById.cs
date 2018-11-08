    using EnterprisePatterns.Api.Common.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EnterprisePatterns.Api.Product.Infrastructure.Persistence.NHibernate.Specification
{
    public class GetByIdBySpecification : Specification<Product>
    {
        private readonly long _ProductId;

        public GetByIdBySpecification(long ProductId)
        {
            _ProductId = ProductId;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return customer => (customer.Id == _ProductId);
        }
    }
}
