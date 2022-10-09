using UnityEngine;

namespace InternalAssets.Scripts
{
    public class SingleplayerScene : MonoBehaviour
    {
        [SerializeField] private MusicPlayer _music;
        [SerializeField] private MainTicker _ticker;
        [SerializeField] private TimeController _timer;

        private void Start()
        {
            SceneLoader.SingleplayerHasLoaded += Initialize;
        }

        private void Initialize(Track track)
        {
            _ticker.Initialize(track);
            _music.Play(track.Clip);
            _timer.Initialize(track.Clip.length + MusicPlayer.PlayDelay);
        }
    }
}