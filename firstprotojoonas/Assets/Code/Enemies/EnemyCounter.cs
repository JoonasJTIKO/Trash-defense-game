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

        private TrashUI trashUI;

        void Start()
        {
            spawner = GetComponent<spawner>();
            endGame = FindObjectOfType<EndGame>();
            trashUI = FindObjectOfType<TrashUI>();
            maxEnemyCount = spawner.spawnAmount;
        }

        public void RemoveEnemy(string type, bool addDestroyed = true)
        {
            maxEnemyCount--;
            if (addDestroyed)
            {
                trashUI.AddAmount(1, type);
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
        }
    }
}