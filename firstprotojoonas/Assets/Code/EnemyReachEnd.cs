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

        void Start()
        {
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
                if(enemyCount == 0)
                {
                    endGame.Lose();
                }
            }
        }
    }
}
