namespace Felice.Data
{
    using NHibernate;

    public interface ISessionBuilder
    {
        ISession GetSession();
    }
}