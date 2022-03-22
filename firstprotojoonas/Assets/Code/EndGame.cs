using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameOverText;

        [SerializeField]
        private GameObject winText;
        private SceneChanger sceneChanger;
        
        void Start()
        {
            sceneChanger = FindObjectOfType<SceneChanger>();
        }
        public void Lose()
        {
            if(winText.activeSelf == false)
            {
                gameOverText.SetActive(true);
            }
        }

        public void Win()
        {
            if(gameOverText.activeSelf == false)
            {
                winText.SetActive(true);
            }
            //testejä, pitää vielä joko tehdä ajastin tai nappi scenen vaihtoa ennen
            sceneChanger.LoadNextLevel();
        }
    }
}
