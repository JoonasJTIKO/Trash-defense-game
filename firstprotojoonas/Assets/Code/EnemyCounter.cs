using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class EnemyCounter : MonoBehaviour
    {
        [SerializeField]
        private int maxEnemyCount;
        private EndGame endGame;
        private spawner spawner;
        private int cardboardAmount = 0;
        private int bioAmount = 0;
        private int plasticAmount = 0;
        private int paperAmount = 0;

        void Start()
        {
            spawner = GetComponent<spawner>();
            endGame = FindObjectOfType<EndGame>();
            maxEnemyCount = spawner.spawnAmount;
        }

        public void RemoveEnemy(string type)
        {
            maxEnemyCount--;

            if(type == "Cardboard")
            {
                cardboardAmount++;
                Debug.Log(cardboardAmount);
            }
            else if(type == "Bio")
            {
                bioAmount++;
                Debug.Log(bioAmount);
            }
            else if(type == "Plastic")
            {
                plasticAmount++;
                Debug.Log(plasticAmount);
            }
            else if(type == "Paper")
            {
                paperAmount++;
                Debug.Log(paperAmount);
            }
            else
            {
                Debug.Log("Enemy does not have type, or type has not been added to counter");
            }

            if(maxEnemyCount == 0)
            {
                endGame.Win();
            }
        }

        private void OnEnable()
        {
            if(spawner != null)
            {
                maxEnemyCount = spawner.spawnAmount;
            }
            cardboardAmount = 0;
            bioAmount = 0;
            plasticAmount = 0;
            paperAmount = 0;
        }
    }
}
