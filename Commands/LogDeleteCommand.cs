using CommandApp.Command;
using CommandApp.Feature;

namespace HabitApp
{
    public class LogDeleteCommand : BaseCommand
    {
        public override string Value { get; } = "8";

        public override string Description { get; } = "Delete log of habit";

        public override IFeature Feature { get; } = new LogDeleteFeature();
    }
}