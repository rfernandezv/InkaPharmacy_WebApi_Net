using InkaPharmacy.Api.Common.Domain.Specification;
using InkaPharmacy.Api.Employees.Domain.Entity;
using System.Collections.Generic;

namespace InkaPharmacy.Api.Security.Domain.Repository
{
    public interface ISecurityRepository
    {
        List<Employee> GetList(
        Specification<Employee> specification);

    }
}
