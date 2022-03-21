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
        }
    }
}
