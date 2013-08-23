﻿namespace Felice.Core.Data
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class TableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(StringHelper.ToLowerUnderscored(instance.EntityType.Name));
        }
    }
}
