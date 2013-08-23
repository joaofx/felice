namespace Felice.TestFramework
{
    using Core.Data;
    using FluentNHibernate.Testing;

    public class MappingTest : IntegratedTest
    {
        protected PersistenceSpecification<T> Entity<T>()
        {
            return new PersistenceSpecification<T>(this.unitOfWork.Session());
        }
    }
}