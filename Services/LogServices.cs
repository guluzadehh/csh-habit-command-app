using CommandApp.App;
using CommandApp.Exceptions;
using HabitApp.Core;

namespace HabitApp
{
    public class LogServices(IApp app)
    {
        public IApp App { get; } = app;
        public BaseRepository<LogEntity> Repository { get; } = new(Helpers.GetConnectionString("HabitDB"));

        public void LogListDisplay(HabitEntity habit)
        {
            IEnumerable<LogEntity> logs = Repository.GetAll().Where((LogEntity log) =>
            {
                return log.HabitId.Value == habit.Id.Value;
            });

            foreach (LogEntity log in logs)
            {
                app.Output.Write($"{log.Id}. [{log.Date.Value}] - {log.Value.Value} {habit.UnitName.Value}");
            }
        }

        public LogEntity Create(HabitEntity habit)
        {
            App.Output.Write($"{habit.Name}\n{habit.Description}");

            string inp = App.Input.Get($"Enter {habit.UnitName}");
            int value;

            try
            {
                value = int.Parse(inp);
            }
            catch (FormatException)
            {
                throw new BaseException($"Wrong int format `{inp}`");
            }

            LogEntity log = new();
            log.Value.Value = value;
            log.HabitId.Value = habit.Id.Value;

            log = Repository.Insert(log);

            return log;
        }

        public bool Delete(HabitEntity habit)
        {
            LogListDisplay(habit);

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

            try
            {
                LogEntity log = Repository.Get(id);

                return Repository.Delete(log);
            }
            catch (Exception exc)
            {
                throw new BaseException("Database Error while deleting the log", exc);
            }
        }
    }
}