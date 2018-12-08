using InkaPharmacy.Api.Common.Domain.Specification;
using System;
using System.Linq.Expressions;

namespace InkaPharmacy.Api.Product.Infrastructure.Persistence.NHibernate.Specification
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
            return product => (product.Id == _ProductId);
        }
    }
}
