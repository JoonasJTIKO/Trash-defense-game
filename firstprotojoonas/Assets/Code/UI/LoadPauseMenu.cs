using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace towerdefense
{
    public class LoadPauseMenu : MonoBehaviour
    {
        
        // opens pause menu and pauses game
        public void LoadMenu()
        {
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
        }

        // closes pause menu and unpauses game
        public void CloseMenu()
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync("PauseMenu");
        }
    }
}
