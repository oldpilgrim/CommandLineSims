using System;
using CommandLineSims.NeighbourMode;

namespace CommandLineSims
{
    public class CommandParser
    {
        private static readonly string Help = "Welcome to CommandLineSims. List of possible commands:\n\n" +
                                              "== Neighbourhood Mode ==\n\n" +
                                              "- new family [family name]\n" +
                                              "- new plot [plot name] [plot size]\n" +
                                              "- move [family name] [plot name]\n" +
                                              "\n" +
                                              "== Live Mode ==\n\n";

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
            command = command.ToLower();

            if (command.Equals("help"))
            {
                Game.PrintLn(Help);
                return;
            }

            switch (Game.currentMode)
            {
                case Mode.Neighbour:
                    _ParseNeighbourhood(command);
                    break;
                case Mode.Live:
                    break;
                case Mode.Buy:
                    break;
                case Mode.Build:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void _ParseNeighbourhood(string command)
        {
            Neighbourhood neighbourhood = SceneManager.currentScene as Neighbourhood;

            if (neighbourhood == null)
            {
                Debug.Error("Current scene is not Neighbourhood but trying to parse command");
                return;
            }
            
            string[] commandParts = command.Split(" ");
            string directive = commandParts[0];

            try
            {
                // Yes this nested if structure isn't particularly neat. Oh well
                if (directive.Equals("new"))
                {
                    string vector = commandParts[1];

                    if (vector.Equals("plot"))
                    {
                        string plotName = commandParts[2];
                        if (!Int32.TryParse(commandParts[3], out int size)) goto End;

                        neighbourhood.CreatePlot(plotName, size);
                        Game.PrintLn($"Creating new plot {plotName}");
                        return;
                    }
                    else if (vector.Equals("family"))
                    {
                        string familyName = commandParts[2];
                        neighbourhood.CreateFamily(familyName);
                        Game.PrintLn($"Creating new family {familyName}");
                        return;
                    }
                }
                else if (directive.Equals("move"))
                {
                    // TODO complete
                }
            }
            catch (IndexOutOfRangeException exception)
            {
                goto End;
            }

            End:
            Game.PrintLn($"'{command}' is not a recognised command in Neighbourhood Mode. Enter 'help' for more.");
        }
    }
}