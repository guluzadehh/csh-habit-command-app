namespace HabitApp.Core
{
    public interface IRepository<T> where T : IEntity
    {
        string ConnectionString { get; }

        T? Get(int id);
        IEnumerable<T> GetAll();

        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}