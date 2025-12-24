using Serilog;

namespace WebSport24hNews.HoangNam.Core.Extensions
{
    public static class LogExtension
    {
        public static void Information(string message)
        {
            Log.Information(message);
        }

        public static void Warning(string message)
        {
            Log.Warning(message);
        }

        public static void Error(string message)
        {
            Log.Error(message);
        }

        public static void Verbose(string message)
        {
            Log.Verbose(message);
        }
    }
}
