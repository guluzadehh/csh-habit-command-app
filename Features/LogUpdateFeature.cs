using CommandApp.Feature;

namespace HabitApp
{
    public class LogUpdateFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices habitServices = new(App);
            HabitEntity habit = habitServices.HabitSelect();

            LogServices logServices = new(App);
            LogEntity log = logServices.LogSelect(habit);
            log = logServices.Update(log);

            SendResponse($"Log [{log.Id}] was updated successfully!");
        }
    }
}