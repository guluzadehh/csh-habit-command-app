using CommandApp.Command;
using CommandApp.Feature;

namespace HabitApp
{
    public class HabitCreateCommand : BaseCommand
    {
        public override string Value { get; } = "3";

        public override string Description { get; } = "Create new habit";

        public override IFeature Feature { get; } = new HabitCreateFeautre();
    }
}