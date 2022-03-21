using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class EnemyCounter : MonoBehaviour
    {
        [SerializeField, Tooltip("this must be the exact amount of enemies that will be spawned in the round")]
        private int maxEnemyCount;

        private EndGame endGame;

        void Start()
        {
            endGame = FindObjectOfType<EndGame>();
        }

        public void RemoveEnemy()
        {
            maxEnemyCount--;
            if(maxEnemyCount == 0)
            {
                endGame.Win();
            }
        }
    }
}
