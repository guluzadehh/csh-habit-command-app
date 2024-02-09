using CommandApp.App;
using CommandApp.Command;

namespace HabitApp;

public static class Program
{
    public static void Main()
    {
        ICommandCollection commands = new DefaultCommandCollection();
        RegisterCommands(commands);

        IApp app = new HabitApp(commands);
        app.Start();
    }

    private static void RegisterCommands(ICommandCollection commands)
    {
        commands.Register(new HabitListCommand());
        commands.Register(new HabitDetailCommand());
        commands.Register(new HabitCreateCommand());
        commands.Register(new HabitDeleteCommand());
        commands.Register(new LogListCommand());
        commands.Register(new LogCreateCommand());
        commands.Register(new LogDeleteCommand());
    }
}