using System;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class PauseUI : MonoBehaviour
    {
        public Action ResumeHasClicked;
        public Action ExitMenuHasClicked;

        [SerializeField] private GameObject _pausePanel;

        public void ResumeClick()
        {
            ResumeHasClicked?.Invoke();
        }

        public void ExitClick()
        {
            ExitMenuHasClicked?.Invoke();
        }

        public void Enable()
        {
            _pausePanel.SetActive(true);
        }

        public void Disable()
        {
            _pausePanel.SetActive(false);
        }
    }
}