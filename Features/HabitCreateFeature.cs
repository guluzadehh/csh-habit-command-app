using CommandApp.Feature;

namespace HabitApp
{
    public class HabitCreateFeautre : BaseFeature
    {
        public override void Run()
        {
            HabitServices services = new(App);
            HabitEntity habit = services.Create();
            SendResponse($"Habit [{habit.Id}] ({habit.Name}) was created successfully!");
        }
    }
}