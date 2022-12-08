using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class Entrance : MonoBehaviour
    {
        private const float waitToStartLoadMenu = 0.5f;

        [SerializeField] private SceneLoader _loader;
        private StartMenu _startMenu;

        private void Start()
        {
            SceneLoader.StartMenuHasLoaded += Initialize;
            SceneLoader.MainMenuHasLoaded += PlayIntro;

            _loader.LoadStartMenu();
        }

        private void OnDestroy()
        {
            SceneLoader.MainMenuHasLoaded -= PlayIntro;
        }

        private void Initialize()
        {
            _startMenu = FindObjectOfType<StartMenu>();

            _startMenu.SoundHasPreEnd += () =>
            {
                _startMenu.gameObject.SetActive(false);
                FindObjectOfType<MainMenuScene>().Initialize();
            };
            _startMenu.SoundHasEnd += () =>
            {
                _loader.UnloadScene(SceneLoader.StartMenu);
                Destroy(gameObject);
            };

            _startMenu.LoadingMenuStage();
            StartCoroutine(DelayedLoadMenu());
        }

        private void PlayIntro()
        {
            _startMenu.PlayLogo();
        }

        private IEnumerator DelayedLoadMenu()
        {
            yield return new WaitForSeconds(waitToStartLoadMenu);
            _loader.LoadMainMenu();
        }
    }
}