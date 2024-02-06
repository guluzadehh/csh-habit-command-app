using System.Data.Common;

namespace HabitApp.Core
{
    public class EntityField<T>(string columnName, T? defaultValue = default)
    {
        public string ColumnName { get; } = columnName;
        public T? Value { get; set; } = defaultValue;

        public void SetFrom(DbDataReader reader)
        {
            Value = reader.GetFieldValue<T>(reader.GetOrdinal(ColumnName));
        }

        public override string? ToString()
        {
            return Value?.ToString();
        }
    }
}