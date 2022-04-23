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

        [SerializeField]
        private GameObject levelClearText;

        private SetSpawner spawner;
        private int wins = 0;
        private bool endless = false;

        void Start()
        {
            spawner = FindObjectOfType<SetSpawner>();
            if(spawner.Endless == true)
            {

            }
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
            if(!endless)
            {
                if(wins == spawner.MaxRounds - 1 && gameOverText.activeSelf == false)
                {
                    levelClearText.SetActive(true);
                }
                else if(gameOverText.activeSelf == false)
                {
                    winText.SetActive(true);
                    wins++;
                }
            }
            else if(endless)
            {
                if(gameOverText.activeSelf == false)
                {
                    winText.SetActive(true);
                    wins++;
                }
            }
        }
    }
}
