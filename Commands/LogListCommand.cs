using CommandApp.Command;
using CommandApp.Feature;

namespace HabitApp
{
    public class LogListCommand : BaseCommand
    {
        public override string Value { get; } = "6";

        public override string Description { get; } = "List logs for habit";

        public override IFeature Feature { get; } = new LogListFeature();
    }
}