using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class enemyTakeDamage : MonoBehaviour
    {
        [SerializeField]
        private int health;
        void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.tag == "Bullet")
            {
                health--;
                if(health == 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
