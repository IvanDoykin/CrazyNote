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
            SceneLoader.StartMenuHasLoaded += () =>
            {
                _startMenu = FindObjectOfType<StartMenu>();

                _startMenu.SoundHasPreEnd += () =>
                {
                    _startMenu.gameObject.SetActive(false);
                };
                _startMenu.SoundHasEnd += () =>
                {
                    _loader.UnloadScene(SceneLoader.StartMenu);
                    Destroy(gameObject);
                };

                _startMenu.LoadingMenuStage();
                StartCoroutine(DelayedLoadMenu());
            };

            SceneLoader.MainMenuHasLoaded += () =>
            {
                _startMenu.CompletedStage();
            };

            _loader.LoadStartMenu();
        }

        private IEnumerator DelayedLoadMenu()
        {
            yield return new WaitForSeconds(waitToStartLoadMenu);
            _loader.LoadMainMenu();
        }
    }
}