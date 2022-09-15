using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InternalAssets.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        public static Action<Track> SingleplayerHasLoaded;
        public static Action MainMenuHasLoaded;
        
        private const string singleplayer = "Singleplayer";
        private const string mainMenu = "MainMenu";

        [SerializeField] private GameObject _loadingScreen;

        private Scene _currentScene;
        private bool _firstLoading = true;

        private void Start()
        {
            StartMainMenu();
        }

        public void StartMainMenu()
        {
            StartCoroutine(AsyncLoadScene(mainMenu, () =>
            {
                MainMenuHasLoaded?.Invoke();
            }));
        }

        public void StartSingleplayerTrack(Track track)
        {
            StartCoroutine(AsyncLoadScene(singleplayer, () =>
            {
                SingleplayerHasLoaded?.Invoke(track);
            }));
        }

        private IEnumerator AsyncLoadScene(string sceneName, Action callback)
        {
            _loadingScreen.SetActive(true);

            if (!_firstLoading)
            {
                AsyncOperation unloadingOldScene = SceneManager.UnloadSceneAsync(_currentScene);
                while (!unloadingOldScene.isDone)
                {
                    yield return null;
                }
            }
            else
            {
                _firstLoading = false;
            }

            AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (!loading.isDone)
            {
                yield return null;
            }

            _currentScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(_currentScene);

            _loadingScreen.SetActive(false);
            callback?.Invoke();
        }
    }
}