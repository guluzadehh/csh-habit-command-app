using CommandApp.Feature;

namespace HabitApp
{
    public class LogCreateFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices habitServices = new(App);
            HabitEntity habit = habitServices.HabitSelect();

            LogServices logServices = new(App);
            LogEntity log = logServices.Create(habit);

            SendResponse($"Log [{log.Id}] was created successfully!");
        }
    }
}