using CommandApp.Feature;

namespace HabitApp
{
    public class LogDeleteFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices habitServices = new(App);
            HabitEntity habit = habitServices.HabitSelect();

            if (habit == null)
            {
                App.Output.WriteAndWait("Habit doesn't exist");
                return;
            }

            LogServices logServices = new(App);

            if (logServices.Delete(habit))
            {
                App.Output.WriteAndWait("Log was deleted successfully!");
            }
        }
    }
}