using CommandApp.App;
using CommandApp.Command;
using HabitApp.Core;

namespace HabitApp
{
    public class HabitListCommand : ICommand
    {
        public string Value { get; } = "1";

        public string Description { get; } = "List habits";

        public void Execute(IApp app)
        {
            BaseRepository<HabitEntity> repository = new(Helpers.GetConnectionString("HabitDB"));

            HabitServices.HabitListDisplay(app, repository);

            app.Output.Wait();
        }
    }
}