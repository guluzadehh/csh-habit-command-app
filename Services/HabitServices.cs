using CommandApp.App;
using CommandApp.Exceptions;
using HabitApp.Core;

namespace HabitApp
{
    public static class HabitServices
    {
        public static void HabitListDisplay(IApp app, IRepository<HabitEntity> repository)
        {
            foreach (HabitEntity habit in repository.GetAll())
            {
                app.Output.Write($"{habit.Id}. {habit.Name}\n");
            }
        }

        public static int HabitSelectId(IApp app, IRepository<HabitEntity> repository)
        {
            HabitListDisplay(app, repository);

            string inp = app.Input.Get("Enter id");

            try
            {
                return int.Parse(inp);
            }
            catch (FormatException)
            {
                throw new BaseException($"Wrong int format `{inp}`");
            }
        }
    }
}