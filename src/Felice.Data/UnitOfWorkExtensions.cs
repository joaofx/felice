namespace Felice.Data
{
    using Core;
    using Felice.Core.Model;
    using NHibernate;

    public static class UnitOfWorkExtensions
    {
        //// TODO: fix
        ////public static ISession Session(this IUnitOfWork unitOfWork)
        ////{
        ////    return Dependency.Resolve<ISessionBuilder>().GetSession();
        ////}

        ////public static IStatelessSession StatelessSession(this IUnitOfWork unitOfWork)
        ////{
        ////    return Dependency.Resolve<ISessionFactoryBuilder>().GetSessionFactory().OpenStatelessSession();
        ////}
    }
}
