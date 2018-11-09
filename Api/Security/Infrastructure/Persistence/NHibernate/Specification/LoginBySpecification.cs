using InkaPharmacy.Api.Common.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Security.Infrastructure.Persistence.NHibernate.Specification
{
    using InkaPharmacy.Api.Employees.Domain.Entity;
    using System.Linq.Expressions;

    public class LoginBySpecification : Specification<Employee>
    {
        private readonly string _usu;
        private readonly string _clave;

        public LoginBySpecification(string usu, string clave)
        {
            _usu = usu;
            _clave = clave;
        }

        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return employee => (employee.Password == _clave && employee.Username == _usu);
        }

    }
}
