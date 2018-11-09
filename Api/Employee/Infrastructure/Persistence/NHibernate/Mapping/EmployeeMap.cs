using FluentNHibernate.Mapping;

namespace InkaPharmacy.Api.Employees.Infrastructure.Persistence.NHibernate.Mapping
{
    using InkaPharmacy.Api.Employees.Domain.Entity;

    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id).Column("Employee_id");
            Map(x => x.Name).Column("Name");
            Map(x => x.Last_name1).Column("Last_name1");
            Map(x => x.Last_name2).Column("Last_name2");
            Map(x => x.Address).Column("Address");
            Map(x => x.Telephone).Column("Telephone");
            Map(x => x.Role_id).Column("Role_id");
            Map(x => x.Store_id).Column("Store_id");
            Map(x => x.Username).Column("Username");
            Map(x => x.Password).Column("Password");
            Map(x => x.Email).Column("Email");
            Map(x => x.Status).Column("Status");
        }
    }
}
