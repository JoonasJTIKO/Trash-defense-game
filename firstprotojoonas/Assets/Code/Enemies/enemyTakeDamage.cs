using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class enemyTakeDamage : MonoBehaviour
    {
        [SerializeField]
        private int health;

        private followPath pathFollow;

        private EnemyCounter enemyCounter;
        
        [SerializeField]
        private string type;

        void Awake()
        {
            pathFollow = GetComponent<followPath>();
            enemyCounter = FindObjectOfType<EnemyCounter>();
        }

        void Update()
        {
            if (health <= 0)
            {
                enemyCounter.RemoveEnemy(type);
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

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "SlowingBullet")
            {
                pathFollow.SetSpeed(2,3);
            }
        }

        public new string GetType()
        {
            return type;
        }
    }
}
