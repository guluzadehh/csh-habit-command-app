using System.Configuration;
using CommandApp;
using CommandApp.App;
using CommandApp.Command;
using CommandApp.Dispatcher;
using CommandApp.Exceptions;
using CommandApp.IO;
using Microsoft.Data.Sqlite;

namespace HabitApp
{
    public class HabitApp : BaseApp
    {
        public override ICommandCollection Commands { get; }

        public override IDispatcher Dispatcher { get; }

        public override ICommandOutput CommandOutput { get; } = new DefaultCommandOutput();

        public override IAppInput Input { get; } = new DefaultAppInput();

        public override IAppOutput Output { get; } = new DefaultAppOutput();

        public override Dictionary<string, object> Context { get; } = [];

        public HabitApp(ICommandCollection commands)
        {
            Commands = commands;
            Dispatcher = new DefaultDispatcher(commands);

            InitDatabase();
        }

        private void InitDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HabitDb"].ConnectionString;

            using (SqliteConnection conn = new(connectionString))
            {
                const string createHabitsQuery =
                    @"CREATE TABLE IF NOT EXISTS habits (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name VARCHAR(255) NOT NULL,
                    description TEXT NOT NULL,
                    unit_name VARCHAR(255) NOT NULL
                );";
                SqliteCommand createHabitsCommand = new(createHabitsQuery, conn);

                const string createLogsQuery =
                    @" CREATE TABLE IF NOT EXISTS logs (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    date DATETIME NOT NULL,
                    value INT NOT NULL DEFAULT 0,
                    habit_id INT NOT NULL,
                    FOREIGN KEY (habit_id) REFERENCES habits(id) ON DELETE CASCADE
                );";
                SqliteCommand createLogsCommand = new(createLogsQuery, conn);

                conn.Open();

                createHabitsCommand.ExecuteNonQuery();
                createLogsCommand.ExecuteNonQuery();
            }
        }
    }
}