﻿namespace Felice.Core.Data
{
    using NHibernate;

    public abstract class DaoBase
    {
        private readonly ISessionBuilder sessionBuilder;

        protected DaoBase()
        {
            this.sessionBuilder = Dependency.Resolve<ISessionBuilder>();
        }

        protected ISession Session
        {
            get { return this.sessionBuilder.GetSession(); }
        }
    }
}
