namespace Felice.TestFramework
{
    using Data;
    using FluentNHibernate.Testing;

    public abstract class MappingTest : IntegratedTest
    {
        protected PersistenceSpecification<T> Entity<T>()
        {
            return new PersistenceSpecification<T>(this.unitOfWork.Session());
        }
    }
}