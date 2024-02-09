using CommandApp.Command;
using CommandApp.Feature;

namespace HabitApp
{
    public class HabitListCommand : BaseCommand
    {
        public override string Value { get; } = "1";

        public override string Description { get; } = "List habits";

        public override IFeature Feature { get; } = new HabitListFeature();
    }
}