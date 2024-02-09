using HabitApp.Core;

namespace HabitApp
{
    public class LogEntity : BaseEntity
    {
        public override string TableName { get; } = "logs";
        public EntityField<DateTime> Date { get; } = new("date", DateTime.Now);
        public EntityField<int> Value { get; } = new("value");
        public EntityField<int> HabitId { get; } = new("habit_id");
    }
}