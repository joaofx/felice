namespace Felice.Data
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.AcceptanceCriteria;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;
    using Felice.Core.Types;

    public class MonthConvention : IPropertyConvention, IPropertyConventionAcceptance
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType(typeof(MonthType));
        }

        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.DeclaringType == typeof(Month));
        }
    }
}
