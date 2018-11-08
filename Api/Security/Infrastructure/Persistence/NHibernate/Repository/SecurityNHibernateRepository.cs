using EnterprisePatterns.Api.Common.Infrastructure.Persistence.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterprisePatterns.Api.Accounts.Infrastructure.Persistence.NHibernate.Repository
{
    using System.Collections.Generic;
    using EnterprisePatterns.Api.Common.Domain.Specification;
    using EnterprisePatterns.Api.Security.Domain.Repository;
    using EnterprisePatterns.Api.Empleado.Domain.Entity;

    public class SecurityNHibernateRepository : BaseNHibernateRepository<Employee>, ISecurityRepository
    {
        public SecurityNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public List<Employee> GetList(Specification<Employee> specification)
        {
            List<Employee> empleados = new List<Employee>();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                empleados = _unitOfWork.GetSession().Query<Employee>()
                    .Where(specification.ToExpression())
                    .ToList();
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return empleados;
        }
    }
}
