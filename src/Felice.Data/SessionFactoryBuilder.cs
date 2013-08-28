namespace Felice.Data
{
    using NHibernate;
    using NHibernate.Cfg;

    public class SessionFactoryBuilder : ISessionFactoryBuilder
    {
        private const string SessionFactory = "sessionFactory";

        private readonly SingletonInstanceScoper<ISessionFactory> sessionFactorySingleton =
            new SingletonInstanceScoper<ISessionFactory>();

        public ISessionFactory GetSessionFactory()
        {
            return this.sessionFactorySingleton.GetScopedInstance(SessionFactory, this.BuildFactory);
        }

        private ISessionFactory BuildFactory()
        {
            Configuration cfg = new HibernateConfiguration().Build();
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            return sessionFactory;
        }
    }
}