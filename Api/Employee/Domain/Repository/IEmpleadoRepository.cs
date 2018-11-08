using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkaPharmacy.Api.Employee.Domain.Repository
{
    using InkaPharmacy.Api.Common.Domain.Specification;
    using InkaPharmacy.Api.Employee.Domain.Entity;

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
