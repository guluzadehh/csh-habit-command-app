using CommandApp.Feature;
using HabitApp.Core;

namespace HabitApp
{
    public class HabitDetailFeature : BaseFeature
    {
        public override void Run()
        {
            BaseRepository<HabitEntity> repository = new(Helpers.GetConnectionString("HabitDB"));

            int id = HabitServices.HabitSelectId(App, repository);

            HabitEntity? habit = repository.Get(id);
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