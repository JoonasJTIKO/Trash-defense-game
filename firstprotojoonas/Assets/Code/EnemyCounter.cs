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

        void Start()
        {
            spawner = GetComponent<spawner>();
            endGame = FindObjectOfType<EndGame>();
            maxEnemyCount = spawner.spawnAmount;
        }

        public void RemoveEnemy()
        {
            maxEnemyCount--;
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
        }
    }
}
