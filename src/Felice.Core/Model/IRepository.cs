namespace Felice.Core.Model
{
    using System.Collections.Generic;

    public interface IRepository<T> where T : Entity
    {
        T ById(long id);

        void Save(T entity);

        IEnumerable<T> All();

        void Delete(T entity);

        void DeleteById(long id);
    }
}