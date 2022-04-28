using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class enemyTakeDamage : MonoBehaviour
    {
        [SerializeField]
        private float health;

        private followPath pathFollow;

        private EnemyCounter enemyCounter;

        [SerializeField]
        private string type;

        [SerializeField]
        private GameObject destroyed1;

        [SerializeField]
        private GameObject destroyed2;

        [SerializeField]
        private float force;

        [SerializeField]
        private GameObject particle1;

        void Awake()
        {
            pathFollow = GetComponent<followPath>();
            enemyCounter = FindObjectOfType<EnemyCounter>();
        }

        // will reduce the enemys health based on what type of projectile hits it, if health reaches 0 enemy will be destroyed, removed from counter, added to trash inventory and
        // the death effects will be spawned
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Bullet")
            {
                health--;
            }
            if (col.gameObject.tag == "SmallBullet")
            {
                health -= 0.75F;
            }
            if (col.gameObject.tag == "Melee")
            {
                health--;
            }
            if (health <= 0)
            {
                enemyCounter.RemoveEnemy(type);
                Destroy(this.gameObject);
                if(destroyed1 != null)
                {
                    GameObject destroyedIns = Instantiate(destroyed1, (Vector2)transform.position, transform.rotation);
                    destroyedIns.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1F, 2F), 1).normalized * force);
                }
                if(destroyed2 != null)
                {
                    GameObject destroyedIns2 = Instantiate(destroyed2, (Vector2)transform.position, transform.rotation);
                    destroyedIns2.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1F, 2F), 1).normalized * force);
                }
                Instantiate(particle1, transform.position, transform.rotation);
            }
        }

        // will slow the enemy if a slowing bullet hits it
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "SlowingBullet")
            {
                pathFollow.SetSpeed(2, 3);
            }
        }

        public new string GetType()
        {
            return type;
        }
    }
}
