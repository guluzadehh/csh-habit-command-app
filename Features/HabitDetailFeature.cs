using CommandApp.Feature;

namespace HabitApp
{
    public class HabitDetailFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices services = new(App);
            HabitEntity? habit = services.HabitSelect();

            if (habit != null)
            {
                SendResponse($"{habit.Id}. {habit.Name}\t{habit.Description}\n-> {habit.UnitName}\n");
            }
            else
            {
                SendResponse("Doesn't exist\n");
            }
        }
    }
}