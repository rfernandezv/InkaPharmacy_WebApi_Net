using InkaPharmacy.Api.Common.Domain.Specification;
using InkaPharmacy.Api.Employees.Domain.Entity;
using System;
using System.Linq.Expressions;

namespace InkaPharmacy.Api.Employees.Infrastructure.Persistence.NHibernate.Specification
{
    public class FindByUsernameBySpecification : Specification<Employee>
    {
        private readonly string _Username;

        public FindByUsernameBySpecification(string Username)
        {
            _Username = Username;
        }

        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return employee => (employee.Username == _Username);
        }
    }
}
