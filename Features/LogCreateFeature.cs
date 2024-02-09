using CommandApp.Feature;

namespace HabitApp
{
    public class LogCreateFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices habitServices = new(App);
            HabitEntity? habit = habitServices.HabitSelect();

            if (habit == null)
            {
                App.Output.WriteAndWait("Habit doesn't exist");
                return;
            }

            LogServices logServices = new(App);
            LogEntity log = logServices.Create(habit!);

            App.Output.WriteAndWait($"Log#{log.Id} was created successfully!");
        }
    }
}