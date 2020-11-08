using System;
using System.Media;

namespace CommandLineSims
{
    public class Program
    {
        public const bool IsDebug = true;
        
        static void Main(string[] args)
        {
            new Game().Run();
        }

        public static void DebugLog(string message)
        {
            if (IsDebug) Console.WriteLine($"[DEBUG] {message}");
        }
    }
}