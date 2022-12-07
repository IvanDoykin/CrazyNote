using System;
using System.Collections;
using System.Collections.Generic;
using InternalAssets.Scripts;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class MainMenuScene : MonoBehaviour
    {
        [SerializeField] private MenuAudio _audio;
        [SerializeField] private MusicHandler _music;
        [SerializeField] private AudioPreview _preview;
        [SerializeField] private MainMenu _mainMenuUI;
        [SerializeField] private SongsPanelsHandler _songsPanelsHandler;

        private AudioClip _clip;
        private Difficulty _difficulty = Difficulty.Expert;
        private string _directory = "";
        private SceneLoader _loader;

        private void Awake()
        {
            _loader = FindObjectOfType<SceneLoader>();
        }

        private void Start()
        {
            _mainMenuUI.AnyButtonHasSelected += _audio.PlayButtonSelected;
            _mainMenuUI.AnyButtonHasClicked += _audio.PlayNext;
            _mainMenuUI.BackButtonHasClicked += _audio.PlayBack;

            _music.ClipHasGot += SetClip;
            
            _mainMenuUI.ExitHasClicked += ExitGame;

            _songsPanelsHandler.PanelHasClicked += HandlePanel;
        }

        public void Initialize()
        {
            _audio.FirstPlay();
            _mainMenuUI.Open();
        }

        private void SetClip(AudioClip clip)
        {
            _clip = clip;
            _preview.SetPreview(clip);
        }

        public void StartGame(string directory, AudioClip clip)
        {
            if (directory != "" && clip != null)
            {
                _loader.LoadSingleplayerTrack(new Track(directory, _difficulty, clip));
            }
        }
        
        private void SetDifficulty(Difficulty difficulty)
        {
            _difficulty = difficulty;
        }
        
        private void HandlePanel(SongPanel panel)
        {
            _music.SetPreview(panel.Directory);
            _directory = panel.Directory;
        }
        
        private void ExitGame()
        {
            Application.Quit();
        }
    }
}