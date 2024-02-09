using CommandApp.Command;
using CommandApp.Feature;

namespace HabitApp
{
    public class LogCreateCommand : BaseCommand
    {
        public override string Value { get; } = "7";

        public override string Description { get; } = "Create new log for habit";

        public override IFeature Feature { get; } = new LogCreateFeature();
    }
}