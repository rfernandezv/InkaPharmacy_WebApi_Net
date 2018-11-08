using InkaPharmacy.Api.Common.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Employee.Infrastructure.Persistence.NHibernate.Specification
{
    using System.Linq.Expressions;
    using InkaPharmacy.Api.Employee.Domain.Entity;

    public class LoggingBySpecification : Specification<Employee>
    {
        private readonly string _usu;
        private readonly string _clave;

        public LoggingBySpecification(string usu, string clave)
        {
            _usu = usu;
            _clave = clave;
        }


        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return empleado => (empleado.Password == _clave && empleado.Username == _usu);
        }

    }
}
