using System.Collections.Generic;
using InkaPharmacy.Api.Common.Domain.Specification;
using InkaPharmacy.Api.Employees.Domain.Entity;

namespace InkaPharmacy.Api.Employees.Domain.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetList(
            Specification<Employee> specification,
            int page = 0,
            int pageSize = 5);

        Employee FindByAnySpecificField(Specification<Employee> specification);
    }

}
