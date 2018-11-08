using InkaPharmacy.Api.Common.Infrastructure.Persistence.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Employee.Infrastructure.Persistence.NHibernate.Repository
{
    using InkaPharmacy.Api.Common.Domain.Specification;
    using InkaPharmacy.Api.Employee.Domain.Entity;
    using InkaPharmacy.Api.Employee.Domain.Repository;

    public class EmployeeNHibernateRepository : BaseNHibernateRepository<Employee>, IEmployeeRepository
    {
        public EmployeeNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public List<Employee> GetList(
            Specification<Employee> specification, 
            //double minimumRating, 
            int page = 0, 
            int pageSize = 5)
        {
            List<Employee> empleados = new List<Employee>();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                empleados = _unitOfWork.GetSession().Query<Employee>()
                    .Where(specification.ToExpression())
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    //.Fetch(x => x.Director)
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
