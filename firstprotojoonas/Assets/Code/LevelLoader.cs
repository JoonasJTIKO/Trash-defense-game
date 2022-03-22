using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace towerdefense
{
    public class LevelLoader : MonoBehaviour
    {
        public enum LoadingState
        {
            None,
            Started,
            InProgress
        }

        public const string LoaderName = "Loader";

        public static LevelLoader Current
        {
            get;
            private set;
        }

        private LoadingState state = LoadingState.None;
        
        private Scene originalScene;
        private string nextSceneName;
        private Scene loadingScene;
        

        private void Awake()
        {
            if (Current == null)
            {
                Current = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);            
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnLevelLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnLevelLoaded;
        }

        public void LoadLevel(string sceneName)
        {
            nextSceneName = sceneName;
            originalScene = SceneManager.GetActiveScene();

            SceneManager.LoadSceneAsync(LoaderName, LoadSceneMode.Additive);
            state = LoadingState.Started;
        }

        private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
        {
            switch(state)
            {
                case LoadingState.Started:
                    loadingScene = scene;
                    GameObject[] rootObjects = loadingScene.GetRootGameObjects();
                    foreach (GameObject item in rootObjects)
                    {
                        Fader fader = item.GetComponentInChildren<Fader>();
                        if (fader != null)
                        {
                            float fadeTime = fader.FadeIn();
                            StartCoroutine(ContinueLoad(fadeTime));

                            break;
                        }
                    }

                    break;
                case LoadingState.InProgress:
                    foreach (GameObject item in loadingScene.GetRootGameObjects())
                    {
                        Fader fader = item.GetComponentInChildren<Fader>();
                        if (fader != null)
                        {
                            float fadeTime = fader.FadeOut();
                            StartCoroutine(FinalizeLoad(fadeTime));

                            state = LoadingState.None;

                            break;
                        }
                    }

                    break;
            }
        }

        private IEnumerator FinalizeLoad(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);

            SceneManager.UnloadSceneAsync(loadingScene);

        }

        private IEnumerator ContinueLoad(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            SceneManager.UnloadSceneAsync(originalScene);
            SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Additive);
            state = LoadingState.InProgress;
        }    
    }
}
