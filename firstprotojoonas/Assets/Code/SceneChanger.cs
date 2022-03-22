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
        private void OnTriggerEnter2D(Collider2D other)
        {
            LevelLoader.Current.LoadLevel(sceneName);
        }
    }
}
