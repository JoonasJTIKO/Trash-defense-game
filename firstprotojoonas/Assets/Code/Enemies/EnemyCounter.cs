using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class EnemyCounter : MonoBehaviour
    {
        [SerializeField]
        public int maxEnemyCount;
        private EndGame endGame;
        private SetSpawner spawner;

        private TrashUI trashUI;

        void Start()
        {
            spawner = GetComponent<SetSpawner>();
            endGame = FindObjectOfType<EndGame>();
            trashUI = FindObjectOfType<TrashUI>();
        }

        //reduce the counter by one, add destroyed trash to "trash inventory" unless otherwise specified, end the round if the counter reaches 0
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
    }
}
