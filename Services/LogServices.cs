using CommandApp.App;
using CommandApp.Exceptions;
using HabitApp.Core;

namespace HabitApp
{
    public class LogServices(IApp app)
    {
        public IApp App { get; } = app;
        public BaseRepository<LogEntity> Repository { get; } = new(Helpers.GetConnectionString("HabitDB"));

        public void LogListDisplay(IEnumerable<LogEntity> logs, HabitEntity habit)
        {
            foreach (LogEntity log in logs)
            {
                App.Output.Write($"{log.Id}. [{log.Date.Value}] - {log.Value.Value} {habit.UnitName.Value}");
            }
        }

        public LogEntity LogSelect(HabitEntity habit)
        {
            List<LogEntity> logs = GetAll(habit);
            if (logs.Count == 0)
            {
                throw new BaseException($"Habit ({habit.Name}) doesn't have logs");
            }

            LogListDisplay(logs, habit);

            int id = Helpers.GetIntInput(App.Input, "Enter id");

            return logs.Find((LogEntity log) => log.Id.Value == id) ?? throw new BaseException($"Log [{id}] doesn't exist");
        }

        public LogEntity Create(HabitEntity habit)
        {
            App.Output.Write($"{habit.Name} - {habit.Description}");

            int value = Helpers.GetIntInput(App.Input, $"Enter {habit.UnitName}");

            LogEntity log = new();
            log.Value.Value = value;
            log.HabitId.Value = habit.Id.Value;

            try
            {
                return Repository.Insert(log);
            }
            catch (Exception exc)
            {
                throw new BaseException("Database Error while creating the log", exc);
            }
        }

        public void Delete(LogEntity log)
        {
            try
            {
                Repository.Delete(log);
            }
            catch (Exception exc)
            {
                throw new BaseException("Database Error while deleting the log", exc);
            }
        }

        public List<LogEntity> GetAll(HabitEntity habit)
        {
            return Repository.GetAll().Where((LogEntity log) =>
                {
                    return log.HabitId.Value == habit.Id.Value;
                }).ToList();
        }
    }
}