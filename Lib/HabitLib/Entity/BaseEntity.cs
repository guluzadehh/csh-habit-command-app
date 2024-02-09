using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace HabitApp.Core
{
    public abstract class BaseEntity : IEntity
    {
        public abstract string TableName { get; }

        public EntityField<int> Id { get; set; } = new("id");

        public void MakeFrom(DbDataReader reader)
        {
            foreach (PropertyInfo prop in Fields())
            {
                object fieldInstance = prop.GetValue(this);
                prop.PropertyType.GetMethod("SetFrom").Invoke(fieldInstance, [reader]);
            }
        }

        public IEnumerable<PropertyInfo> Fields()
        {
            Type target = typeof(EntityField<>);

            return GetType().GetProperties().Where((PropertyInfo prop) =>
            {
                return prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == target;
            });
        }
    }
}