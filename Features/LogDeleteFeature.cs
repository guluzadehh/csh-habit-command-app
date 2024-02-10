using CommandApp.Feature;

namespace HabitApp
{
    public class LogDeleteFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices habitServices = new(App);
            HabitEntity habit = habitServices.HabitSelect();

            LogServices logServices = new(App);
            LogEntity log = logServices.LogSelect(habit);
            logServices.Delete(log);

            SendResponse($"Log [{log.Id}] was deleted successfully!");
        }
    }
}