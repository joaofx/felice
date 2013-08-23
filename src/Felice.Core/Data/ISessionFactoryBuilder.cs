namespace Felice.Core.Data
{
    using NHibernate;

    public interface ISessionFactoryBuilder
    {
        ISessionFactory GetSessionFactory();
    }
}