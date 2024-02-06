
using Microsoft.Data.Sqlite;

namespace HabitApp.Core
{
    public class BaseRepository<T>(string connectionString) : IRepository<T> where T : BaseEntity
    {
        public string ConnectionString { get; } = connectionString;

        public EntityFactory<T> Factory { get; } = new();

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T? Get(int id)
        {
            using (SqliteConnection conn = new(ConnectionString))
            {
                T entity = CreateInstance();

                string query = $"SELECT * FROM {entity.TableName} WHERE id = @Id;";

                SqliteCommand command = new(query, conn);
                command.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqliteDataReader reader = command.ExecuteReader();

                reader.Read();

                entity.MakeFrom(reader);

                reader.Close();

                return entity;
            }
        }
        public IEnumerable<T> GetAll()
        {
            using (SqliteConnection conn = new(ConnectionString))
            {
                string query = $"SELECT * FROM {CreateInstance().TableName};";

                SqliteCommand command = new(query, conn);

                conn.Open();

                SqliteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        T entity = CreateInstance();
                        entity.MakeFrom(reader);
                        yield return entity;
                    }
                }
            }

            yield break;
        }

        public T Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        protected T CreateInstance()
        {
            return (T)Activator.CreateInstance(typeof(T))!;
        }
    }
}