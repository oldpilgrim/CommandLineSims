using System;

namespace CommandLineSims
{
    public class CommandParser
    {
        private static readonly string Help = "Welcome to CommandLineSims. List of possible commands:\n\n" +
                                              "== Neighbourhood Mode ==\n\n" +
                                              "";
        
        public static void BeginParse()
        {
            while (true)
            {
                Console.Write("$ ");
                _Parse(Console.ReadLine());
            }
        }

        private static void _Parse(string command)
        {
            switch (command.ToLower())
            {
                case "help":
                    Game.PrintLn(Help);
                    break;
                default:
                    Game.PrintLn($"'{command}' is not a recognised command. Enter 'help' for more.");
                    break;
            }
        }
    }
}