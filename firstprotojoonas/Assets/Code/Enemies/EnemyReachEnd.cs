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

        [SerializeField]
        private EnemyCounter enemyCounter;

        void Awake()
        {
            endGame = FindObjectOfType<EndGame>();
        }

        // will destroy an enemy once they reach the endpoint and reduce the counter by one, if too many enemies reach the end the round will end in a loss
        void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.tag == "Enemy")
            {
                Destroy(col.gameObject);
                enemyCount--;
                enemyCounter.RemoveEnemy(col.gameObject.GetComponent<enemyTakeDamage>().GetType(), false);
                if(enemyCount == 0)
                {
                    endGame.Lose();
                }
            }
        }
    }
}
