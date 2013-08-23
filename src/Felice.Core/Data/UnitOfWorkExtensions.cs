﻿namespace Felice.Core.Data
{
    using Model;
    using NHibernate;

    public static class UnitOfWorkExtensions
    {
        public static ISession Session(this IUnitOfWork unitOfWork)
        {
            return Dependency.Resolve<ISessionBuilder>().GetSession();
        }

        public static IStatelessSession StatelessSession(this IUnitOfWork unitOfWork)
        {
            return Dependency.Resolve<ISessionFactoryBuilder>().GetSessionFactory().OpenStatelessSession();
        }
    }
}
