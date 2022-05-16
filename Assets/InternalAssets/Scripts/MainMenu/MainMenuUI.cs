using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.MainMenu.SongSelecting;

namespace Game.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        private void Start()
        {
            DifficultyButton.HasClicked += (DifficultyButton button) => Track.Instance.SetDifficulty(button.Difficulty);
            SongPanelButton.HasClicked += (SongPanelButton button) => Track.Instance.SetDirectory(button.GetComponent<SongPanel>().Directory);
            SongPanelButton.HasClicked += (SongPanelButton button) => FindObjectOfType<AudioPreview>().SetPreview(button.GetComponent<SongPanel>().Directory);
            StartGameButton.HasClicked += (StartGameButton button) => Track.Instance.StartTrack();
        }
    }
}