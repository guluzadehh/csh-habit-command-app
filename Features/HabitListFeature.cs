using CommandApp.Feature;

namespace HabitApp
{
    public class HabitListFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices services = new(App);
            services.HabitListDisplay();

            App.Output.Wait();
        }
    }
}