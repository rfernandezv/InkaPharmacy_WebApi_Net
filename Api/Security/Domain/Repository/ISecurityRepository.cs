namespace InkaPharmacy.Api.Security.Domain.Repository
{
    using InkaPharmacy.Api.Common.Domain.Specification;
    using InkaPharmacy.Api.Employees.Domain.Entity;
    using System.Collections.Generic;

    public interface ISecurityRepository
    {
        //void Create(Employee employee);
        //void Delete(Employee employee);
        //Employee Read(int id);

        List<Employee> GetList(
         Specification<Employee> specification);

    }
}
