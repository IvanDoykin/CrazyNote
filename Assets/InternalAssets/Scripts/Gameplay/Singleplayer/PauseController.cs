using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class PauseController : MonoBehaviour
    {
        public Action GameHasPaused;
        public Action GameHasResume;
        public Action GameExitedToMainMenu;

        [SerializeField] private PauseUI _ui;
        [SerializeField] private GuitarAnimator _guitarAnimator;

        private GameInput _input;
        private bool _pause = false;

        private void Start()
        {
            _input = GetComponent<GameInput>();

            _ui.ResumeHasClicked += Resume;
            _ui.ExitMenuHasClicked += BackToMainMenu;
        }

        private void OnDestroy()
        {
            _ui.ResumeHasClicked -= Resume;
            _ui.ExitMenuHasClicked -= BackToMainMenu;
        }

        private void Update()
        {
            var input = _input.GetServiceInput();

            if (input.IsPausePressed)
            {
                ChangePauseState();
            }
        }

        private void BackToMainMenu()
        {
            GameExitedToMainMenu?.Invoke();
        }

        private void Resume()
        {
            _ui.Disable();
            _guitarAnimator.SetActive();
            _pause = false;
            GameHasResume?.Invoke();
        }

        private void Pause()
        {
            _ui.Enable();
            _guitarAnimator.SetInactive();
            _pause = true;
            GameHasPaused?.Invoke();
        }

        private void ChangePauseState()
        {
            if (_pause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}