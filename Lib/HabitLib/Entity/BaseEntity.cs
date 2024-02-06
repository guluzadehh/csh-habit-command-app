using System.Data.Common;
using System.Reflection;

namespace HabitApp.Core
{
    public abstract class BaseEntity : IEntity
    {
        public abstract string TableName { get; }

        public EntityField<int> Id { get; set; } = new("id");

        public void MakeFrom(DbDataReader reader)
        {
            Type target = typeof(EntityField<>);

            foreach (PropertyInfo prop in GetType().GetProperties())
            {
                if (prop.PropertyType.IsGenericType
                    && prop.PropertyType.GetGenericTypeDefinition() == target)
                {
                    object fieldInstance = prop.GetValue(this);
                    prop.PropertyType.GetMethod("SetFrom").Invoke(fieldInstance, [reader]);
                }
            }
        }
    }
}