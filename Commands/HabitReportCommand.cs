using CommandApp.Command;
using CommandApp.Feature;

namespace HabitApp
{
    public class HabitReportCommand : BaseCommand
    {
        public override string Value { get; } = "10";

        public override string Description { get; } = "Report habits per day";

        public override IFeature Feature { get; } = new HabitReportFeature();
    }
}