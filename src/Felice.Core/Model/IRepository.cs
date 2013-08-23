namespace Felice.Core.Model
{
    public interface IRepository<T> where T : Entity
    {
        T ById(long id);

        void Save(T entity);

        T[] All();

        void Delete(T entity);

        void DeleteById(long id);
    }
}