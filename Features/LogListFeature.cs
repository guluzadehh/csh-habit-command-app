using CommandApp.Feature;

namespace HabitApp
{
    public class LogListFeature : BaseFeature
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

            App.Output.Write($"{habit.Name}\n{habit.Description}\n\nLogs:\n");

            LogServices logServices = new(App);
            logServices.LogListDisplay(habit);

            App.Output.Write("\n");
            App.Output.Wait();
        }
    }
}