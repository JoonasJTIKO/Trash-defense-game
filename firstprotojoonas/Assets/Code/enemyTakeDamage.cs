using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class enemyTakeDamage : MonoBehaviour
    {
        [SerializeField]
        private int health;

        private EnemyCounter enemyCounter;

        void Awake()
        {
            enemyCounter = FindObjectOfType<EnemyCounter>();
        }

        void Update()
        {
            if (health <= 0)
            {
                enemyCounter.RemoveEnemy();
                Destroy(this.gameObject);
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Bullet")
            {
                health--;
            }
            if (col.gameObject.tag == "Melee")
            {
                health--;
            }
        }
    }
}
