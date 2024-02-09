using CommandApp.Feature;

namespace HabitApp
{
    public class HabitDeleteFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices services = new(App);
            HabitEntity habit = services.HabitSelect();

            if (habit == null)
            {
                App.Output.WriteAndWait("Habit doesn't exist.");
                return;
            }

            if (services.Delete(habit))
            {
                App.Output.WriteAndWait($"{habit.Name} was deleted successfully!");
            }
        }
    }
}