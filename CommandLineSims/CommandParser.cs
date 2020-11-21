using System;
using System.IO;
using CommandLineSims.NeighbourMode;

namespace CommandLineSims
{
    public class CommandParser
    {
        private static readonly string HelpPath = "../../../../README.txt";

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
            if (command.ToLower().Equals("help"))
            {
                string help = File.ReadAllText(HelpPath);
                Game.PrintLn(help);
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

        #region Neighbourhood

        private static void _ParseNeighbourhood(string command)
        {
            Neighbourhood neighbourhood = SceneManager.currentScene as Neighbourhood;

            if (neighbourhood == null)
            {
                Debug.Error("Current scene is not Neighbourhood but trying to parse command");
                return;
            }
            
            string[] commandParts = command.Split(" ");
            string directive = commandParts[0].ToLower();

            try
            {
                // Yes this nested if structure isn't particularly neat. Oh well
                // edit: solution is to delegate to smaller functions. Then can return in the smaller functions
                // without having to use goto statement
                if (directive.Equals("new"))
                {
                    if (_ParseNeighbourhoodNew(commandParts, neighbourhood)) return;
                }
                else if (directive.Equals("move"))
                {
                    if (_ParseNeighbourhoodMove(commandParts, neighbourhood)) return;
                }
                else if (directive.Equals("play"))
                {
                    // TODO
                }
                else if (directive.Equals("info"))
                {
                    if (_ParseNeighbourhoodInfo(commandParts, neighbourhood)) return;
                }
            }
            catch (IndexOutOfRangeException exception)
            {
                Debug.Log(exception.ToString());
                goto End;
            }

            End:
            Game.PrintLn($"'{command}' is not a recognised command in Neighbourhood Mode. Enter 'help' for more.");
        }
        
        private static bool _ParseNeighbourhoodNew(string[] commandParts, Neighbourhood neighbourhood)
        {
            string vector = commandParts[1];

            if (vector.Equals("plot"))
            {
                string plotName = commandParts[2];
                if (!Int32.TryParse(commandParts[3], out int size)) return false;
                // delegate printing to function. In fact, why not delegate whenever possible? No need to keep track of pesky return values
                neighbourhood.CreatePlot(plotName, size);
                return true;
            }
            else if (vector.Equals("family"))
            {
                string familyName = commandParts[2];
                neighbourhood.CreateFamily(familyName);
                return true;
            }

            return false;
        }

        private static bool _ParseNeighbourhoodMove(string[] commandParts, Neighbourhood neighbourhood)
        {
            string familyName = commandParts[1];
            string plotName = commandParts[2];
            neighbourhood.Move(familyName, plotName);
            // only return false when command not recognised.
            return true;
        }

        private static bool _ParseNeighbourhoodInfo(string[] commandParts, Neighbourhood neighbourhood)
        {
            string vector = commandParts[1];

            if (vector.Equals("plot"))
            {
                string plotName = commandParts[2];
                neighbourhood.QueryPlot(plotName);
                return true;
            }
            else if (vector.Equals("family"))
            {
                string familyName = commandParts[2];
                neighbourhood.QueryFamily(familyName);
                return true;
            }

            return false;
        }

        #endregion
    }
}