﻿using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace InkaPharmacy.Api.Common.Infrastructure.Persistence.NHibernate
{
    public class TableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(Util.getTableName(instance.EntityType.Name));
        }
    }
}
