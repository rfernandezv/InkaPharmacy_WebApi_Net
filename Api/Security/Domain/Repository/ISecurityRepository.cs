using EnterprisePatterns.Api.BankAccounts.Domain.Entity;

namespace EnterprisePatterns.Api.Security.Domain.Repository
{
    using EnterprisePatterns.Api.Common.Domain.Specification;
    using EnterprisePatterns.Api.Empleado.Domain.Entity;
    using System.Collections.Generic;

    public interface ISecurityRepository
    {
        //void Create(Employee empleado);
        //void Delete(Employee empleado);
        //Employee Read(int id);

        List<Employee> GetList(
         Specification<Employee> specification);

    }
}
