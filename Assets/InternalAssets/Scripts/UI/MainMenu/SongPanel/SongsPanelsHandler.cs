using System;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class SongsPanelsHandler : MonoBehaviour
    {
        public Action<SongPanel> PanelHasClicked;

        [SerializeField] private GameObject _songPanelPrefab;
        [SerializeField] private Transform _songsPanelsPlace;
        
        private void Start()
        {
            CreatePanels();
        }

        private void OnPanelClicked(SongPanel panel)
        {
            PanelHasClicked?.Invoke(panel);    
        }

        private void CreatePanels()
        {
            foreach (var songDirectory in SongsFinder.FindSongsDirectories())
            {
                var songPanelObj = Instantiate(_songPanelPrefab, _songsPanelsPlace);
                var songPanel = songPanelObj.GetComponent<SongPanel>();
                songPanel.CreateFromDirectory(songDirectory + "\\");

                songPanel.HasClicked += OnPanelClicked;
            }
        }
    }
}