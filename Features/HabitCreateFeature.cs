using CommandApp.Feature;

namespace HabitApp
{
    public class HabitCreateFeautre : BaseFeature
    {
        public override void Run()
        {
            HabitServices services = new(App);
            HabitEntity habit = services.Create();
            App.Output.WriteAndWait($"Habit#{habit.Id} ({habit.Name}) was created successfully!");
        }
    }
}