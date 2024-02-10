using CommandApp.Feature;

namespace HabitApp
{
    public class HabitUpdateFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices services = new(App);
            HabitEntity habit = services.Update();
            SendResponse($"Habit [{habit.Id}] ({habit.Name}) was updated successfully!");
        }
    }

}