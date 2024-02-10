using System.Configuration;
using CommandApp.Exceptions;
using CommandApp.IO;

namespace HabitApp
{
    public static class Helpers
    {
        public static string GetConnectionString(string db)
        {
            return ConfigurationManager.ConnectionStrings[db].ConnectionString;
        }

        public static int GetIntInput(IAppInput AppInput, string? infoText = null)
        {
            string inp = AppInput.Get(infoText);

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