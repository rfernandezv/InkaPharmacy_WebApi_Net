using FluentNHibernate.Mapping;

namespace InkaPharmacy.Api.Customers.Infrastructure.Persistence.NHibernate.Mapping
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id).Column("customer_id").Nullable();
            Map(x => x.Name).Column("Name");
            Map(x => x.Last_Name1).Column("Last_Name1");
            Map(x => x.Last_Name2).Column("Last_Name2").Nullable();
            Map(x => x.Address).Column("Address").Nullable();
            Map(x => x.Telephone).Column("Telephone").Nullable();
            Map(x => x.Email).Column("Email").Nullable();
            Map(x => x.Document_Number).Column("Document_Number").Nullable();
            Map(x => x.Status).Column("Status").Nullable();
        }
    }
}
