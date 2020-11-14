using System;
using System.Media;

namespace CommandLineSims
{
    public class Game
    {
        public void Run()
        {
            SoundManager.PlayNeighbourhood();
            GameManager.Loop();

            // TODO
            string command = Console.ReadLine();
        }
    }
}