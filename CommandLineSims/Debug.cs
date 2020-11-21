using System;

namespace CommandLineSims
{
    public static class Debug
    {
        public enum LogLevel
        {
            Debug, Warn, Error, None
        }
        
        public const LogLevel Level = LogLevel.Warn;

        public static void Log(string message)
        {
            if (Level <= LogLevel.Debug)
            {
                Console.WriteLine($"[DEBUG] {message}");
            }
        }

        public static void Warn(string message)
        {
            if (Level <= LogLevel.Warn)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[WARN] {message}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        
        public static void Error(string message)
        {
            if (Level <= LogLevel.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR] {message}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}