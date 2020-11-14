using System;

namespace CommandLineSims
{
    public class CommandParser
    {
        public static void BeginParse()
        {
            while (true)
            {
                _Parse(Console.ReadLine());
            }
        }

        private static void _Parse(string command)
        {
            switch (command.ToLower())
            {
                case "help":
                    Console.WriteLine("Welcome to CommandLineSims. Blah blah blah TODO");
                    break;
                default:
                    Console.WriteLine($"'{command}' is not a recognised command. Enter 'help' for more.");
                    break;
            }
        }
    }
}