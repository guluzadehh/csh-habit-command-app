using CommandApp.Command;
using CommandApp.Feature;

namespace HabitApp
{
    public class HabitUpdateCommand : BaseCommand
    {
        public override string Value { get; } = "5";

        public override string Description { get; } = "Update habit";

        public override IFeature Feature { get; } = new HabitUpdateFeature();
    }

}