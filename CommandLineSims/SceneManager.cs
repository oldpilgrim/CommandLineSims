using System.Collections.Generic;
using CommandLineSims.NeighbourMode;

namespace CommandLineSims
{
    public static class SceneManager
    {
        public static Scene currentScene { get; private set; }
        
        public static void LoadNeighbourhood()
        {
            // TODO should load from save file.
            // currently creates an empty Neighbourhood

            currentScene = new Neighbourhood(families: new List<Family>(), plots: new List<Plot>());
        }
    }
}