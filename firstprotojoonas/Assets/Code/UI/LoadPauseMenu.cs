using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace towerdefense
{
    public class LoadPauseMenu : MonoBehaviour
    {
        public void LoadMenu()
        {
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
        }

        public void CloseMenu()
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync("PauseMenu");
        }
    }
}
