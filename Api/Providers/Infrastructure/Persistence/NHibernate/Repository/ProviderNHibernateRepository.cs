using InkaPharmacy.Api.Common.Infrastructure.Persistence.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using InkaPharmacy.Api.Common.Domain.Specification;
using InkaPharmacy.Api.Providers.Domain.Repository;
using InkaPharmacy.Api.Providers.Domain.Entity;

namespace InkaPharmacy.Api.Providers.Infrastructure.Persistence.NHibernate.Repository
{


    public class ProviderNHibernateRepository : BaseNHibernateRepository<Provider>, IProviderRepository
    {
        public ProviderNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public List<Provider> GetList(
            Specification<Provider> specification,
            int page = 0,
            int pageSize = 5)
        {
            List<Provider> providers = new List<Provider>();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                providers = _unitOfWork.GetSession().Query<Provider>()
                    .Where(specification.ToExpression())
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return providers;
        }

        public Provider FindByAnySpecificField(Specification<Provider> specification)
        {
            Provider provider = new Provider();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                provider = _unitOfWork.GetSession().Query<Provider>()
                .Where(specification.ToExpression()).FirstOrDefault();
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return provider;
        }
    }
}
