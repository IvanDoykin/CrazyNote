using UnityEngine;

namespace InternalAssets.Scripts
{
    public class SingleplayerScene : MonoBehaviour
    {
        [SerializeField] private MusicPlayer _music;
        [SerializeField] private MainTicker _ticker;

        private void Start()
        {
            SceneLoader.SingleplayerHasLoaded += Initialize;
        }

        private void Initialize(Track track)
        {
            _ticker.Initialize(track);
            _music.Play(track.Clip);
        }
    }
}