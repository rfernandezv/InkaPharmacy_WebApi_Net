using FluentNHibernate.Mapping;

namespace EnterprisePatterns.Api.Customers.Infrastructure.Persistence.NHibernate.Mapping
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id).Column("customer_id");
            Map(x => x.Name).Column("Name");
            Map(x => x.Last_Name1).Column("Last_Name1");
            Map(x => x.Last_Name2).Column("Last_Name2");
            Map(x => x.Address).Column("Address");
            Map(x => x.Telephone).Column("Telephone");
            Map(x => x.Email).Column("Email");
            Map(x => x.Document_Number).Column("Document_Number");
            Map(x => x.Status).Column("Status");
        }
    }
}
