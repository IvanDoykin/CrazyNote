using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InternalAssets.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        private const string singleplayer = "Singleplayer";
        private const string mainMenu = "MainMenu";
        private const string startMenu = "StartMenu";

        public static Action<Track> SingleplayerHasLoaded;
        public static Action MainMenuHasLoaded;
        public static Action StartMenuHasLoaded;
        
        [SerializeField] private GameObject _loadingScreen;

        public void LoadStartMenu()
        {
            StartCoroutine(AsyncLoadScene(startMenu, () =>
            {
                StartMenuHasLoaded?.Invoke();
            }));
        }

        public void LoadMainMenu()
        {
            StartCoroutine(AsyncLoadScene(mainMenu, () =>
            {
                MainMenuHasLoaded?.Invoke();
            }));
        }

        public void LoadSingleplayerTrack(Track track)
        {
            StartCoroutine(AsyncLoadScene(singleplayer, () =>
            {
                SingleplayerHasLoaded?.Invoke(track);
            }));
        }
        public void UnloadScene(string sceneName)
        {
            StartCoroutine(AsyncUnloadScene(sceneName));
        }

        private IEnumerator AsyncLoadScene(string sceneName, Action callback)
        {
            _loadingScreen.SetActive(sceneName != startMenu);

            AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (!loading.isDone)
            {
                yield return null;
            }

            var loadedScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(loadedScene);

            _loadingScreen.SetActive(false);
            callback?.Invoke();
        }

        private IEnumerator AsyncUnloadScene(string sceneName)
        {
            var unloadingScene = SceneManager.GetSceneByName(sceneName);

            AsyncOperation unloading = SceneManager.UnloadSceneAsync(sceneName);
            while (!unloading.isDone)
            {
                yield return null;
            }
        }
    }
}