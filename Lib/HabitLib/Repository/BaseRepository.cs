
using System.Reflection;
using Microsoft.Data.Sqlite;

namespace HabitApp.Core
{
    public class BaseRepository<T>(string connectionString) : IRepository<T> where T : BaseEntity
    {
        public string ConnectionString { get; } = connectionString;

        public bool Delete(T entity)
        {
            string query = $"DELETE FROM {entity.TableName} WHERE id = @Id";

            using (SqliteConnection conn = new(ConnectionString))
            {
                SqliteCommand command = new(query, conn);
                command.Parameters.AddWithValue("@Id", entity.Id.Value);

                conn.Open();
                return command.ExecuteNonQuery() == 1;
            }
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
                try
                {

                    SqliteDataReader reader = command.ExecuteReader();

                    reader.Read();

                    entity.MakeFrom(reader);

                    reader.Close();
                }
                catch
                {
                    return null;
                }


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
            Dictionary<string, string> values = [];

            string query = $"INSERT INTO {entity.TableName}";
            string columns = "(";
            string parameters = "(";

            foreach (PropertyInfo prop in entity.Fields())
            {
                if (prop.Name == "Id") continue;

                object fieldInstance = prop.GetValue(entity);

                PropertyInfo valueProp = prop.PropertyType.GetProperty("Value")!;
                PropertyInfo columnProp = prop.PropertyType.GetProperty("ColumnName");

                object value = valueProp.GetValue(fieldInstance).ToString();
                object column = (string)columnProp.GetValue(fieldInstance);

                columns += column.ToString() + ",";

                string parameter = "@" + column.ToString();
                parameters += parameter + ",";

                values[parameter] = value.ToString();
            }

            columns = columns.Remove(columns.Length - 1);
            columns += ")";

            parameters = parameters.Remove(parameters.Length - 1);
            parameters += ")";

            query += columns + " VALUES " + parameters + ";";

            query += "SELECT last_insert_rowid();";

            using (SqliteConnection conn = new(ConnectionString))
            {
                SqliteCommand command = new(query, conn);

                foreach (KeyValuePair<string, string> kv in values)
                {
                    command.Parameters.AddWithValue(kv.Key, kv.Value);
                }

                conn.Open();

                int id = Convert.ToInt32(command.ExecuteScalar());

                entity.Id.Value = id;

                return entity;
            }


            throw new Exception();
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