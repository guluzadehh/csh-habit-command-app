using System.Configuration;

namespace HabitApp
{
    public static class Helpers
    {
        public static string GetConnectionString(string db)
        {
            return ConfigurationManager.ConnectionStrings[db].ConnectionString;
        }
    }
}