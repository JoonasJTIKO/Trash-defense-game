using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace towerdefense
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField]
        private string sceneName;
        public void LoadNextLevel()
        {
            LevelLoader.Current.LoadLevel(sceneName);
        }
    }
}
