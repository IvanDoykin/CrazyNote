using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Game.MainMenu.ChartParsing;
using Game.MainMenu.SongSelecting;
using System;

namespace Game
{
    public class Track : MonoBehaviour
    {
        private const string GameSceneName = "Singleplayer";
        public static Track Instance { get; private set; }

        public Difficulty Difficulty { get; private set; } = Difficulty.Medium;
        public string Directory { get; private set; }

        public Song Song { get; private set; }
        public SyncTrack SyncTrack { get; private set; }
        public Notes Notes { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(this);
            }
        }

        public void SetDifficulty(Difficulty difficulty)
        {
            Difficulty = difficulty;
        }

        public void SetDirectory(string directory)
        {
            if (directory.Length != 0)
            {
                Directory = directory;
            }
        }

        public void StartTrack()
        {
            SetTrack(Directory, Difficulty);
            if (Song.Resolution != 0 && SyncTrack.TrackBlock.Infos.Count > 0 && Notes.TrackBlock.Infos.Count > 0)
            {
                SceneManager.LoadScene(GameSceneName, LoadSceneMode.Single);
            }
        }

        private void SetTrack(string directory, Difficulty difficulty)
        {
            Song = SongBlockParser.Get(directory);
            SyncTrack = new SyncTrack(TrackBlockParser.Get(directory, BlockName.SyncTrack));
            Notes = new Notes(TrackBlockParser.Get(directory, (BlockName)Enum.Parse(typeof(BlockName), difficulty.ToString() + "Single")));
        }
    }
}