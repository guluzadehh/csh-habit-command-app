using CommandApp.Feature;

namespace HabitApp
{
    public class LogListFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices habitServices = new(App);
            HabitEntity habit = habitServices.HabitSelect();

            App.Output.Write($"{habit.Name} - {habit.Description}\n\nLogs:\n");

            LogServices logServices = new(App);
            logServices.LogListDisplay(logServices.GetAll(habit), habit);

            App.Output.Write("\n");
            App.Output.Wait();
        }
    }
}