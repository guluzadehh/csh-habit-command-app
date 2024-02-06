namespace HabitApp.Core
{
    public interface IEntity
    {
        EntityField<int> Id { get; set; }
    }
}