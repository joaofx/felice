namespace Felice.Data
{
    using System.Collections.Generic;
    using Felice.Core.Model;
    using NHibernate;

    public class Repository<T> : IRepository<T> where T : Entity
    {
        public Repository(ISession session)
        {
            Session = session;
        }

        protected ISession Session
        {
            get;
            private set;
        }

        public virtual T ById(long id)
        {
            return Session.Get<T>(id);
        }

        public virtual void Save(T entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public virtual IEnumerable<T> All()
        {
            var criteria = Session.CreateCriteria(typeof(T));
            return criteria.List<T>();
        }

        public virtual void Delete(T entity)
        {
            Session.Delete(entity);
        }

        public virtual void DeleteById(long id)
        {
            Session.Delete(string.Format("from {0} where Id = {1}", typeof(T).Name, id));
        }
    }
}