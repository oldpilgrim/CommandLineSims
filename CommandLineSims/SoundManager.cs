using System;
using System.Collections.Generic;
using System.Media;
using System.Threading.Tasks;

namespace CommandLineSims
{
    public class SoundManager
    {
        // singleton. Field initialised
        // This would normally not be possible as game objects are instantiated by the game engine 
        private static readonly SoundManager Instance = new SoundManager();
        private static readonly Random Random = new Random();
        private const string Path = "../../../audio/";

        private static readonly IReadOnlyList<string> Latin = new[]
        {
            "latin1.wav",
            "latin2.wav",
            "latin4.wav",
            "latin6.wav",
            "latin7.wav",
        };
        
        #region API
        
        public static async void PlayNeighbourhood()
        {
            // https://stackoverflow.com/questions/37367104/check-when-sound-is-finished-c-sharp
            // TODO interrupt

            await Task.Run(() =>
            {
                // get random track
                string location = Path + Latin[Random.Next(0, Latin.Count)];
                Instance._musicPlayer.SoundLocation = location;
                Instance._musicPlayer.PlaySync();
            });
            
            // play on repeat
            PlayNeighbourhood();
        }
        
        #endregion

        private readonly SoundPlayer _musicPlayer = new SoundPlayer();
        private readonly SoundPlayer _sfxPlayer = new SoundPlayer();
    }
}