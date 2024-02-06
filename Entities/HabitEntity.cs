using HabitApp.Core;

namespace HabitApp
{
    public class HabitEntity : BaseEntity
    {
        public override string TableName { get; } = "habits";
        public EntityField<string> Name { get; } = new("name", "");
        public EntityField<string> Description { get; } = new("description", "");
        public EntityField<string> UnitName { get; set; } = new("unit_name", "");

    }
}