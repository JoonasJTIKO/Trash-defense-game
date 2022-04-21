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
        private GameObject destroyed;

        [SerializeField]
        private float force;

        [SerializeField]
        private GameObject particle;

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
                GameObject destroyedIns = Instantiate(destroyed, (Vector2)transform.position, transform.rotation);
                Instantiate(particle, transform.position, transform.rotation);
                destroyedIns.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 2), 1).normalized * force);
            }
        }

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
        }

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
