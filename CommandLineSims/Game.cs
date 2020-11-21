using System;

namespace CommandLineSims
{
    public class Game
    {
        public static readonly string WelcomeMessage = "Welcome to CommandLineSims. Enter commands after the $ symbol:";
        
        public void Run()
        {
            PrintLn(WelcomeMessage);
            SoundManager.PlayNeighbourhood();
            GameManager.Loop();
            
            // has to be done last as is a blocking call
            CommandParser.BeginParse();
        }
        
        /// <summary>
        /// Prints a message above the current input line, in a different colour.
        /// </summary>

        public static void PrintLn(string message)
        {
            /*
             * 1. Store current cursor position
             * 2. Move current line down
             * 3. Go to previous line and print
             * 4. Restore cursor position
             */
            
            int storedCursorLeft = Console.CursorLeft;
            Console.MoveBufferArea(0, Console.CursorTop, Console.BufferWidth, 1, 0, Console.CursorTop + 1);
            Console.CursorLeft = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.CursorLeft = storedCursorLeft;
        }
    }
}