using InkaPharmacy.Api.Common.Domain.Specification;
using System;
using InkaPharmacy.Api.Employees.Domain.Entity;
using System.Linq.Expressions;

namespace InkaPharmacy.Api.Security.Infrastructure.Persistence.NHibernate.Specification
{
    public class LoginBySpecification : Specification<Employee>
    {
        private readonly string _username;
        private readonly string _password;

        public LoginBySpecification(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return employee => (employee.Password == _password && employee.Username == _username);
        }

    }
}
