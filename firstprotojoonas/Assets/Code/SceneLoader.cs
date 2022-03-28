using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace towerdefense
{
    public class SceneLoader : MonoBehaviour
    {
        static int currentScene = 0;

        private GameObject everything;

        [SerializeField]
        private bool unloadScene;

        void Start()
        {
            everything = GameObject.Find("Everything");
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
            if (currentScene == 1)
            {
                checkForTrashLeft();
            }
        }

        private void checkForTrashLeft()
        {
            if (GameObject.FindGameObjectsWithTag("Trash").Length == 0)
            {
                SceneManager.UnloadSceneAsync("Playermovement");
                currentScene = 0;
                everything.SetActive(true);
                // Start next level
            }
        }

        void changeCurrentSceneIndex()
        {
            currentScene = 1;
        }
    }
}
