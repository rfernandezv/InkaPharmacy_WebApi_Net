using InkaPharmacy.Api.Common.Infrastructure.Persistence.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InkaPharmacy.Api.Employees.Infrastructure.Persistence.NHibernate.Repository
{
    using InkaPharmacy.Api.Common.Domain.Specification;
    using InkaPharmacy.Api.Employees.Domain.Entity;
    using InkaPharmacy.Api.Employees.Domain.Repository;

    public class EmployeeNHibernateRepository : BaseNHibernateRepository<Employee>, IEmployeeRepository
    {
        public EmployeeNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public List<Employee> GetList(
            Specification<Employee> specification, 
            int page = 0, 
            int pageSize = 5)
        {
            List<Employee> Employees = new List<Employee>();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                Employees = _unitOfWork.GetSession().Query<Employee>()
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
            return Employees;
        }

        public Employee FindByAnySpecificField(Specification<Employee> specification)
        {
            Employee employee = new Employee();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                employee = _unitOfWork.GetSession().Query<Employee>()
                .Where(specification.ToExpression()).FirstOrDefault();
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return employee;
        }
    }
}
