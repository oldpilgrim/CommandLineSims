using System;

namespace CommandLineSims
{
    public class Game
    {
        public void Run()
        {
            SoundManager.PlayNeighbourhood();
            GameManager.Loop();
            
            // has to be done last as is a blocking call
            CommandParser.BeginParse();
        }
        
        /// <summary>
        /// Prints a message above the current input line.
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
            Console.WriteLine(message);
            Console.CursorLeft = storedCursorLeft;
        }
    }
}