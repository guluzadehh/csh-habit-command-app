using CommandApp.App;
using CommandApp.Exceptions;
using HabitApp.Core;
using Microsoft.Data.Sqlite;

namespace HabitApp
{
    public class HabitServices(IApp app)
    {
        public IApp App { get; } = app;
        public BaseRepository<HabitEntity> Repository { get; } = new(Helpers.GetConnectionString("HabitDB"));

        public void HabitListDisplay(IEnumerable<HabitEntity> habits)
        {
            foreach (HabitEntity habit in habits)
            {
                App.Output.Write($"{habit.Id}. {habit.Name}\n");
            }
        }

        public HabitEntity HabitSelect()
        {
            List<HabitEntity> habits = Repository.GetAll().ToList();
            if (habits.Count == 0)
            {
                throw new BaseException("No habit created.");
            }

            HabitListDisplay(habits);

            int id = Helpers.GetIntInput(App.Input, "Enter id");

            return habits.Find(
                (HabitEntity habit) => habit.Id.Value == id
            ) ?? throw new BaseException($"Habit [{id}] doesn't exist");
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
                return Repository.Insert(habit);
            }
            catch (SqliteException exc)
            {
                throw new BaseException("Database Error while creating the habit", exc);
            }
        }

        public void Delete(HabitEntity habit)
        {
            try
            {
                Repository.Delete(habit);
            }
            catch (SqliteException exc)
            {
                throw new BaseException("Database Error while deleting the habit", exc);
            }
        }

        public HabitEntity Update()
        {
            HabitEntity habit = HabitSelect();

            try
            {
                habit.Name.Value = App.Input.Get("Enter name (q! for default)");
            }
            catch (QuitInputRead) { }


            try
            {
                habit.Description.Value = App.Input.Get("Enter description (q! for default)");
            }
            catch (QuitInputRead) { }


            try
            {
                habit.UnitName.Value = App.Input.Get("Enter unit name (q! for default)");
            }
            catch (QuitInputRead) { }

            try
            {
                return Repository.Update(habit);
            }
            catch (SqliteException exc)
            {
                throw new BaseException("Database Error while updating the habit", exc);
            }
        }
    }
}