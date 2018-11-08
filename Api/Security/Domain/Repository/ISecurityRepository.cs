namespace InkaPhatmacy.Api.Security.Domain.Repository
{
    using InkaPhatmacy.Api.Common.Domain.Specification;
    using InkaPhatmacy.Api.Empleado.Domain.Entity;
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
