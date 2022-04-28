using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace towerdefense
{
    public class SceneLoader : MonoBehaviour
    {
        static int currentScene = 0;

        //every gameobject in scene that needs to be turned off when going to sorting scene
        private GameObject everything;

        [SerializeField]
        private bool unloadScene;

        private TrashUI trashUI;

        void Start()
        {
            everything = GameObject.Find("Everything");
            trashUI = FindObjectOfType<TrashUI>();
        }
        public void LoadScene(string name)
        {
            if (unloadScene)
            {
                SceneManager.LoadScene(name);
                return;
            } 
            else 
            {
                SceneManager.LoadScene(name, LoadSceneMode.Additive);
            }
            everything.SetActive(false);
            if (currentScene == 0)
            {
                Invoke("changeCurrentSceneIndex", 1.0f);
            }
            
        }

        void Update()
        {
            if (everything == null)
            {
                everything = GameObject.Find("Everything");
            }
        }

        public void swapScene()
        {
            SceneManager.UnloadSceneAsync("Playermovement");
            currentScene = 0;
            everything.SetActive(true);
            trashUI.Reset();
        }

        void changeCurrentSceneIndex()
        {
            currentScene = 1;
        }
    }
}
