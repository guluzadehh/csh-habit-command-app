using CommandApp.Feature;

namespace HabitApp
{
    public class HabitDetailFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices services = new(App);
            HabitEntity habit = services.HabitSelect();
            SendResponse($"{habit.Id}. {habit.Name} - {habit.Description}\n-> {habit.UnitName}\n");
        }
    }
}