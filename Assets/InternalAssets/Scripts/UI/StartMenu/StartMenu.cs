using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class StartMenu : MonoBehaviour
    {
        public Action SoundHasPreEnd;
        public Action SoundHasEnd;

        [SerializeField] private LoadingPanel _loading;
        [SerializeField] private StartMenuBackground _background;
        [SerializeField] private LogoAnimation _logo;
        [SerializeField] private StartMenuSound _sound;

        private void Start()
        {
            _sound.HasPreEnd += () =>
            {
                SoundHasPreEnd?.Invoke();
            };
            _sound.HasEnd += () =>
            {
                SoundHasEnd?.Invoke();
            };
        }

        public void LoadingMenuStage()
        {
            _loading.LoadingMenu();
            _background.FadeOutTo(0.5f);
        }

        public void CompletedStage()
        {
            _background.InstantFadeIn();
            _loading.gameObject.SetActive(false);

            _background.FullFadeIn();
            _logo.Play();
            _sound.Play();
        }
    }
}