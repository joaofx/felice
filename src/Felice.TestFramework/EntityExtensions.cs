namespace Felice.TestFramework
{
    using System;
    using Core;
    using Core.Model;
    using NHibernate;
    using Should;

    public static class EntityExtensions
    {
        public static T Persist<T>(this T entity)
        {
            var session = Dependency.Resolve<ISession>();

            session.SaveOrUpdate(entity);
            session.Flush();

            return entity;
        }

        public static T Delete<T>(this T entity) where T : Entity
        {
            var session = Dependency.Resolve<ISession>();

            session.Delete(entity);
            session.Flush();

            return entity;
        }

        public static void ShouldNotBeLazy(this object proxy)
        {
            NHibernateUtil.IsInitialized(proxy).ShouldBeTrue();
        }

        public static void ShouldBeLazy(this object proxy)
        {
            NHibernateUtil.IsInitialized(proxy).ShouldBeFalse();
        }

        public static T With<T>(this T entity, Action<T> overrides) where T : Entity
        {
            overrides(entity);
            return entity;
        }
    }
}
