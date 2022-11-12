using UnityEngine;

namespace InternalAssets.Scripts
{
    public class SingleplayerScene : MonoBehaviour
    {
        [SerializeField] private MusicPlayer _music;
        [SerializeField] private MainTicker _ticker;
        [SerializeField] private TimeController _timer;
        [SerializeField] private GuitarControl _control;
        [SerializeField] private PauseController _pause;
        private SceneLoader _loader;

        private void Awake()
        {
            _loader = FindObjectOfType<SceneLoader>();
        }

        private void Start()
        {
            SceneLoader.SingleplayerHasLoaded += Initialize;

            _pause.GameHasPaused += Pause;
            _pause.GameHasResume += Resume;
            _pause.GameExitedToMainMenu += ExitMenu;
        }

        private void OnDestroy()
        {
            SceneLoader.SingleplayerHasLoaded -= Initialize;

            _pause.GameHasPaused -= Pause;
            _pause.GameHasResume -= Resume;
            _pause.GameExitedToMainMenu -= ExitMenu;
        }

        public void Pause()
        {
            _music.Pause();
            _ticker.SetInactive();
            _timer.SetInactive();
            _control.SetInactive();

            foreach (var wide in FindObjectsOfType<Wide>())
            {
                wide.GetComponent<Mover>().SetInactive();
            }
        }

        public void Resume()
        {
            _music.Resume();
            _ticker.SetActive();
            _timer.SetActive();
            _control.SetActive();

            foreach (var wide in FindObjectsOfType<Wide>())
            {
                wide.GetComponent<Mover>().SetActive();
            }
        }

        public void ExitMenu()
        {
            _loader.LoadMainMenu();
        }

        private void Initialize(Track track)
        {
            _music.Play(track.Clip);
            _ticker.Initialize(track);
            _timer.Initialize(track.Clip.length + MusicPlayer.PlayDelay);
        }
    }
}