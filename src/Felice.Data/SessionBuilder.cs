namespace Felice.Data
{
    using NHibernate;

    public class SessionBuilder : ISessionBuilder
    {
        private const string NhibernateSession = "NHibernate.ISession";
        private readonly HybridInstanceScoper<ISession> hybridInstanceScoper;
        private readonly ISessionFactoryBuilder sessionFactoryBuilder;

        public SessionBuilder()
        {
            this.hybridInstanceScoper = new HybridInstanceScoper<ISession>();
            this.sessionFactoryBuilder = new SessionFactoryBuilder();
        }

        public ISession GetSession()
        {
            ISession instance = this.GetScopedInstance();

            if (instance.IsOpen == false)
            {
                this.hybridInstanceScoper.ClearScopedInstance(NhibernateSession);
                return this.GetScopedInstance();
            }

            return instance;
        }

        private ISession GetScopedInstance()
        {
            return this.hybridInstanceScoper.GetScopedInstance(NhibernateSession, this.BuildSession);
        }

        private ISession BuildSession()
        {
            ISessionFactory factory = this.sessionFactoryBuilder.GetSessionFactory();
            ISession session = factory.OpenSession();
            //// TODO: poder configurar FlushMode global
            session.FlushMode = FlushMode.Commit;
            return session;
        }
    }
}