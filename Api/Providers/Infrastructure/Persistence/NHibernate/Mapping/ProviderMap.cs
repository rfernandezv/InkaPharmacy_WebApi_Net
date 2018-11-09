using FluentNHibernate.Mapping;
using InkaPharmacy.Api.Providers.Domain.Entity;

namespace InkaPharmacy.Api.Providers.Infrastructure.Persistence.NHibernate.Mapping
{
    public class ProviderMap : ClassMap<Provider>
    {
        public ProviderMap()
        {
            Id(x => x.Id).Column("provider_id");
            Map(x => x.Name).Column("name");
            Map(x => x.DocumentNumber).Column("document_number");
            Map(x => x.Address).Column("address");
            Map(x => x.Telephone).Column("telephone");
            Map(x => x.Status).Column("status");
        }
    }
}
