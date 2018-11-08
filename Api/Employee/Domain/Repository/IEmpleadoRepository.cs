using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPhatmacy.Api.Employee.Domain.Repository
{
    using InkaPhatmacy.Api.Common.Domain.Specification;
    using InkaPhatmacy.Api.Empleado.Domain.Entity;

    public interface IEmployeeRepository
    {
        //void Create(Employee empleado);
        //void Delete(Employee empleado);
        //Employee Read(int id);

        List<Employee> GetList(
            Specification<Employee> specification,
            //double minimumRating,
            int page = 0,
            int pageSize = 5);

    }

}
