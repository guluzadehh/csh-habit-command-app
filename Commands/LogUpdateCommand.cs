using CommandApp.Command;
using CommandApp.Feature;

namespace HabitApp
{
    public class LogUpdateCommand : BaseCommand
    {
        public override string Value { get; } = "9";

        public override string Description { get; } = "Update log";

        public override IFeature Feature { get; } = new LogUpdateFeature();
    }
}