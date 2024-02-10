using CommandApp.Feature;

namespace HabitApp
{
    public class HabitReportFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices habitServices = new(App);
            HabitEntity habit = habitServices.HabitSelect();

            int days = Helpers.GetIntInput(App.Input, "Enter days");

            DateTime limitDate = DateTime.Today.AddDays(-days);
            double result = 0.0;

            LogServices logServices = new(App);
            foreach (LogEntity log in logServices.GetAll(habit))
            {
                if (log.Date.Value >= limitDate)
                {
                    result += log.Value.Value;
                }
            }

            SendResponse($"You have logs of total {result} units since {limitDate}");
        }
    }
}