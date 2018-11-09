using InkaPharmacy.Api.Common.Domain.Specification;
using InkaPharmacy.Api.Providers.Domain.Entity;
using System;
using System.Linq.Expressions;

namespace InkaPharmacy.Api.Providers.Infrastructure.Persistence.NHibernate.Specification
{
    public class FindByDocumentNumberBySpecification : Specification<Provider>
    {
        private readonly string _DocumentNumber;

        public FindByDocumentNumberBySpecification(string DocumentNumber)
        {
            _DocumentNumber = DocumentNumber;
        }

        public override Expression<Func<Provider, bool>> ToExpression()
        {
            return provider => (provider.DocumentNumber == _DocumentNumber);
        }
    }
}
