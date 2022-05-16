using UnityEngine;

namespace Game.MainMenu.SongSelecting
{
    public class SongsPanelsCreator : MonoBehaviour
    {
        [SerializeField] private GameObject _songPanelPrefab;
        [SerializeField] private Transform _songsPanelsPlace;
        private SongsFinder _songsFinder;

        private void Awake()
        {
            _songsFinder = FindObjectOfType<SongsFinder>();
        }

        private void Start()
        {
            CreatePanels();
        }

        public void CreatePanels()
        {
            foreach (var songDirectory in _songsFinder.FindSongsDirectories())
            {
                GameObject songPanelObj = Instantiate(_songPanelPrefab, _songsPanelsPlace);
                SongPanel songPanel = songPanelObj.GetComponent<SongPanel>();
                songPanel.CreateFromDirectory(songDirectory + "\\");
            }
        }
    }
}
