namespace Felice.Core.Data
{
    using NHibernate;

    public interface ISessionBuilder
    {
        ISession GetSession();
    }
}