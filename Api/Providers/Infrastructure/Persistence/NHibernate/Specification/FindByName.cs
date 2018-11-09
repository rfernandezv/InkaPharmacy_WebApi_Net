using InkaPharmacy.Api.Common.Domain.Specification;
using InkaPharmacy.Api.Providers.Domain.Entity;
using System;
using System.Linq.Expressions;

namespace InkaPharmacy.Api.Providers.Infrastructure.Persistence.NHibernate.Specification
{
    public class FindByNameSpecification : Specification<Provider>
    {
        private readonly string _name;

        public FindByNameSpecification(string Name)
        {
            _name = Name;
        }

        public override Expression<Func<Provider, bool>> ToExpression()
        {
            return provider => (provider.Name == _name);
        }
    }
}
