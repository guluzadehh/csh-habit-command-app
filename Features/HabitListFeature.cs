using CommandApp.Feature;

namespace HabitApp
{
    public class HabitListFeature : BaseFeature
    {
        public override void Run()
        {
            HabitServices services = new(App);
            services.HabitListDisplay(services.Repository.GetAll());
            App.Output.Wait();
        }
    }
}