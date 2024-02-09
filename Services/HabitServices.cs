using CommandApp.App;
using CommandApp.Exceptions;
using HabitApp.Core;

namespace HabitApp
{
    public class HabitServices(IApp app)
    {
        public IApp App { get; } = app;
        public BaseRepository<HabitEntity> Repository { get; } = new(Helpers.GetConnectionString("HabitDB"));

        public void HabitListDisplay()
        {
            foreach (HabitEntity habit in Repository.GetAll())
            {
                App.Output.Write($"{habit.Id}. {habit.Name}\n");
            }
        }

        public HabitEntity? HabitSelect()
        {
            HabitListDisplay();

            string inp = App.Input.Get("Enter id");
            int id;

            try
            {
                id = int.Parse(inp);
            }
            catch (FormatException)
            {
                throw new BaseException($"Wrong int format `{inp}`");
            }

            return Repository.Get(id);
        }

        public HabitEntity Create()
        {
            string habitName = App.Input.Get("Enter name");
            string habitDesc = App.Input.Get("Enter description");
            string habitUnitName = App.Input.Get("Enter unit name");

            HabitEntity habit = new();
            habit.Name.Value = habitName;
            habit.Description.Value = habitDesc;
            habit.UnitName.Value = habitUnitName;

            try
            {
                habit = Repository.Insert(habit);
            }
            catch (Exception exc)
            {
                throw new BaseException("Database Error while creating the habit", exc);
            }

            return habit;
        }

        public bool Delete(HabitEntity habit)
        {
            try
            {
                return Repository.Delete(habit);
            }
            catch (Exception exc)
            {
                throw new BaseException("Database Error while deleting the habit", exc);
            }
        }
    }
}