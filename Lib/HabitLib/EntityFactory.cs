using System.Data.Common;

namespace HabitApp.Core
{
    public class EntityFactory<T> where T : BaseEntity
    {
        public T Create(DbDataReader reader)
        {
            T entity = (T)Activator.CreateInstance(typeof(T))!;
            entity.MakeFrom(reader);
            return entity;
        }
    }
}