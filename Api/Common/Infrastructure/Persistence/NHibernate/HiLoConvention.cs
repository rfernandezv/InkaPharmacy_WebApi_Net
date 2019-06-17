using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace InkaPharmacy.Api.Common.Infrastructure.Persistence.NHibernate
{
    public class HiLoConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            var column = Util.getTableName(instance.EntityType.Name) + "_id";
            instance.Column(column);
            instance.GeneratedBy.Native();
        }
    }
}
