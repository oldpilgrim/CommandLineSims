using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using static CommandLineSims.Program;

namespace CommandLineSims
{
    public class SoundManager
    {
        // singleton. Field initialised
        // This would normally not be possible as game objects are instantiated by the game engine 
        private static readonly SoundManager Instance = new SoundManager();
        private const string Path = "../../../audio/";

        private static readonly IReadOnlyList<string> Latin = new[]
        {
            "latin1.wav",
            "latin2.wav",
            "latin4.wav",
            "latin6.wav",
            "latin7.wav",
        };
        
        private SoundManager() {}

        #region API
        
        public static void PlayNeighbourhood()
        {
            Instance._cts?.Cancel();
            Instance._PlayNeighbourhood();
        }

        public static void PlayBuild()
        {
            Instance._cts?.Cancel();
            Instance._PlayBuild();
        }
        
        #endregion

        // fields should be non static where possible so can be automatically disposed
        private readonly SoundPlayer _musicPlayer = new SoundPlayer();
        private readonly SoundPlayer _sfxPlayer = new SoundPlayer();
        private readonly Random _random = new Random();
        
        private CancellationTokenSource _cts;
        
        private async void _PlayNeighbourhood()
        {
            // https://stackoverflow.com/questions/37367104/check-when-sound-is-finished-c-sharp
            // uniquely identifies the task to cancel. See https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-cancellation
            _cts = new CancellationTokenSource();

            Task playTask = Task.Run(() =>
            {
                _PlayRandomFromList(Latin);
            }, _cts.Token);
            
            try
            {
                await playTask;
            }
            catch (TaskCanceledException e)
            {
                DebugLog("Play task cancelled");
                return;
            }

            // play on repeat
            _PlayNeighbourhood();
        }

        private async void _PlayBuild()
        {
            // TODO
        }
        
        private void _PlayRandomFromList(IReadOnlyList<string> playlist)
        {
            int trackNum = _random.Next(0, playlist.Count);
            string location = Path + playlist[trackNum];
            DebugLog($"Playing track {trackNum} from playlist {nameof(playlist)}");
            Instance._musicPlayer.SoundLocation = location;
            Instance._musicPlayer.PlaySync();
            DebugLog("Finished playing track");
        }
    }
}