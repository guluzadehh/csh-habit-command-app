using CommandApp.Feature;

namespace HabitApp
{
    public class HabitDeleteFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices services = new(App);

            HabitEntity habit = services.HabitSelect();
            services.Delete(habit);

            SendResponse($"Habit ({habit.Name}) was deleted successfully!");
        }
    }
}