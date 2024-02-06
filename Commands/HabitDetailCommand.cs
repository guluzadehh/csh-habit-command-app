using CommandApp.Command;
using CommandApp.Feature;

namespace HabitApp
{
    public class HabitDetailCommand : BaseCommand
    {
        public override string Value { get; } = "2";

        public override string Description { get; } = "Habit detail";

        public override IFeature Feature { get; } = new HabitDetailFeature();

    }
}