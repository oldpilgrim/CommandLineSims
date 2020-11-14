using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandLineSims
{
    public class GameManager
    {
        // 50 frames per second
        public const int UpdateIntervalMillis = 20;
        private static readonly GameManager Instance = new GameManager();

        #region API
        
        public static void Add(IUpdateable updateable)
        {
            Instance._updateables.Add(updateable);
        }

        public static void Loop()
        {
            Instance._Loop();
        }
        
        #endregion
        
        private readonly List<IUpdateable> _updateables = new List<IUpdateable>();
        private int _frameCount;

        private async void _Loop()
        {
            while (true)
            {
                Parallel.ForEach(_updateables, updateable => updateable.Update());
                await Task.Delay(UpdateIntervalMillis);
                
                // debug stuff
                unchecked
                {
                    _frameCount++;
                }

                // DebugLog($"Frame number {_frameCount}");
            }
        }
    }
}