using System;
using System.Collections.Generic;
using System.Linq;
using InkaPhatmacy.Api.Common.Domain.Specification;
using InkaPhatmacy.Api.Common.Infrastructure.Persistence.NHibernate;
using InkaPhatmacy.Api.Customers.Domain.Repository;

namespace InkaPhatmacy.Api.Customers.Infrastructure.Persistence.NHibernate.Repository
{
    class CustomerCustomerNHibernateRepository : BaseNHibernateRepository<Customer>, ICustomerRepository
    {
        public CustomerCustomerNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public Customer FindByDocumentNumber(Specification<Customer> specification)
        {
            Customer customer = new Customer();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                customer = _unitOfWork.GetSession().Query<Customer>()
                .Where(specification.ToExpression()).FirstOrDefault();
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return customer;
        }
    }
}
