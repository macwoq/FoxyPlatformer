using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class LevelLoader : MonoBehaviour
    {

        private static int mainMenuIndex = 1;

        [SerializeField]
        private LoadProgressBar _loadProgressBarPrefab;
        private LoadProgressBar _loadProgressBar;

        public static void LoadLevel(string levelName)
        {
            if (Application.CanStreamedLevelBeLoaded(levelName))
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("GAMEMANAGER LoadLevel Error: invalid scene specified!");
            }
        }

        public static void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                if (levelIndex == LevelLoader.mainMenuIndex)
                {
                    
                }

                // for async loading, we need a specific object
                LevelLoader levelLoader = Object.FindObjectOfType<LevelLoader>();

                // load with progress bar if we find a LevelLoad object
                if (levelLoader != null)
                {
                    levelLoader.LoadLevelAsync(levelIndex);
                    Debug.Log("Load Level " + levelIndex);
                }
                // otherwise load immediately
                else
                {
                    SceneManager.LoadScene(levelIndex);
                }
            }
            else
            {
                Debug.LogWarning("LEVELLOADER LoadLevel Error: invalid scene specified!");
            }
        }

        // start the coroutine to load asynchronously and generate a progress bar prefab
        private void LoadLevelAsync(int levelIndex)
        {
            if (_loadProgressBarPrefab != null)
            {
                _loadProgressBar = Object.Instantiate(_loadProgressBarPrefab, Vector3.zero, Quaternion.identity);
                _loadProgressBar.InitSlider();
            }

            StartCoroutine(LoadLevelAsyncRoutine(levelIndex));

        }

        // load a level asynchronously and update the load progress bar
        private IEnumerator LoadLevelAsyncRoutine(int levelIndex)
        {

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);
            asyncLoad.allowSceneActivation = false;

            if (_loadProgressBar != null)
            {
                while (_loadProgressBar.sliderValue < 0.9f)
                {
                    _loadProgressBar.UpdateProgress(asyncLoad.progress);

                    yield return null;
                }
            }
            yield return null;
            asyncLoad.allowSceneActivation = true;


        }

        public static void ReloadLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().name);
        }

        public static void LoadNextLevel()
        {
            int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1)
                % SceneManager.sceneCountInBuildSettings;
            nextSceneIndex = Mathf.Clamp(nextSceneIndex, mainMenuIndex, nextSceneIndex);
            LoadLevel(nextSceneIndex);
        }

        public static void LoadMainMenuLevel()
        {
            LoadLevel(mainMenuIndex);
        }

    }
}
