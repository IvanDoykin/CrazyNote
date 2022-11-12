using System;
using System.Collections;
using System.Collections.Generic;
using InternalAssets.Scripts;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class MainMenuScene : MonoBehaviour
    {
        [SerializeField] private MusicHandler _music;
        [SerializeField] private AudioPreview _audio;
        [SerializeField] private MainMenuUI _ui;
        [SerializeField] private SongsPanelsHandler _songsPanelsHandler;

        private AudioClip _clip;
        private Difficulty _difficulty;
        private string _directory = "";
        private SceneLoader _loader;

        private void Awake()
        {
            _loader = FindObjectOfType<SceneLoader>();
        }

        private void Start()
        {
            _music.ClipHasGot += SetClip;
            
            _ui.DifficultyHasSelected += SetDifficulty;
            _ui.ExitButtonHasClicked += ExitGame;
            _ui.StartGameHasClicked += StartGame;

            _songsPanelsHandler.PanelHasClicked += HandlePanel;
        }

        private void SetClip(AudioClip clip)
        {
            _clip = clip;
            _audio.SetPreview(clip);
        }

        private void StartGame()
        {
            if (_directory != "" && _clip != null)
            {
                _loader.LoadSingleplayerTrack(new Track(_directory, _difficulty, _clip));
            }
        }
        
        private void SetDifficulty(Difficulty difficulty)
        {
            _difficulty = difficulty;
        }
        
        private void HandlePanel(SongPanel panel)
        {
            _music.GetMusic(panel.Directory);
            _directory = panel.Directory;
        }
        
        private void ExitGame()
        {
            Application.Quit();
        }
    }
}