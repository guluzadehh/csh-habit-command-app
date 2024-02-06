
using Microsoft.Data.Sqlite;

namespace HabitApp.Core
{
    public class BaseRepository<T>(string connectionString) : IRepository<T> where T : BaseEntity
    {
        public string ConnectionString { get; } = connectionString;

        public EntityFactory<T> Factory { get; } = new();

        private string _tableName = (string)(typeof(T).GetProperty("TableName")?.GetValue(null) ?? "");

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T? Get(int id)
        {
            using (SqliteConnection conn = new(ConnectionString))
            {
                string query = $"SELECT * FROM {_tableName} WHERE id = @Id;";

                SqliteCommand command = new(query, conn);
                command.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqliteDataReader reader = command.ExecuteReader();

                if (!reader.HasRows) return null;

                reader.Read();

                T habit = Factory.Create(reader);

                reader.Close();
                return habit;
            }
        }
        public IEnumerable<T> GetAll()
        {
            using (SqliteConnection conn = new(ConnectionString))
            {
                string query = $"SELECT * FROM {_tableName};";

                SqliteCommand command = new(query, conn);

                conn.Open();

                SqliteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return Factory.Create(reader);
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
    }
}