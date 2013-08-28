namespace Felice.Data
{
    using System.Linq;
    using Core;
    using Felice.Core.Model;
    using NHibernate;

    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private readonly ISessionBuilder sessionBuilder = Dependency.Resolve<ISessionBuilder>();

        protected ISession Session
        {
            get
            {
                return this.sessionBuilder.GetSession();    
            }
        }

        public virtual T ById(long id)
        {
            return this.Session.Get<T>(id);
        }

        public virtual void Save(T entity)
        {
            this.Session.SaveOrUpdate(entity);
        }

        public virtual T[] All()
        {
            var criteria = this.Session.CreateCriteria(typeof(T));
            return criteria.List<T>().ToArray();
        }

        public virtual void Delete(T entity)
        {
            this.Session.Delete(entity);
        }

        public virtual void DeleteById(long id)
        {
            this.Session.Delete(
                string.Format("from {0} where Id = {1}", typeof(T).Name, id));
        }
    }
}