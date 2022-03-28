using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class EnemyReachEnd : MonoBehaviour
    {
        [SerializeField]
        private int enemyCount = 3;

        private EndGame endGame;

        private EnemyCounter enemyCounter;

        void Awake()
        {
            enemyCounter = FindObjectOfType<EnemyCounter>();
            endGame = FindObjectOfType<EndGame>();
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log("enemy reached");
            if(col.gameObject.tag == "Enemy")
            {
                Debug.Log("enemy detected");
                Destroy(col.gameObject);
                enemyCount--;
                enemyCounter.RemoveEnemy();
                if(enemyCount == 0)
                {
                    endGame.Lose();
                }
            }
        }
    }
}
