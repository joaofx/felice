namespace Felice.TestFramework
{
    using Core;
    using FluentNHibernate.Testing;
    using NHibernate;

    public abstract class MappingTest : IntegratedTest
    {
        protected PersistenceSpecification<T> Entity<T>()
        {
            var session = Dependency.Resolve<ISession>();
            return new PersistenceSpecification<T>(session);
        }
    }
}