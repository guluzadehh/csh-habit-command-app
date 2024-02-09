using CommandApp.Command;
using CommandApp.Feature;

namespace HabitApp
{
    public class HabitDeleteCommand : BaseCommand
    {
        public override string Value { get; } = "4";

        public override string Description { get; } = "Delete habit";

        public override IFeature Feature { get; } = new HabitDeleteFeature();
    }
}