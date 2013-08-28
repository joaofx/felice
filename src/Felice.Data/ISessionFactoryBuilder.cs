namespace Felice.Data
{
    using NHibernate;

    public interface ISessionFactoryBuilder
    {
        ISessionFactory GetSessionFactory();
    }
}