namespace Felice.Core.Data
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class ColumnNameConvention : IPropertyConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(StringHelper.ToLowerUnderscored(instance.EntityType.Name));
        }

        public void Apply(IPropertyInstance instance)
        {
            instance.Column(StringHelper.ToLowerUnderscored(instance.Property.Name));
        }
    }
}
