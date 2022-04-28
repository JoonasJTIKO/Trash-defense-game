using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class SlowingBullet : MonoBehaviour
    {
        [SerializeField]
        private float dissipateTime = 1;
        private bool dissipate = false;
        private Collider2D thisCollider;

        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.tag == "Enemy")
            {
                dissipate = true;
            }
        }

        // after hitting an enemy the bullet will be destroyed after a delay
        void Update()
        {
            if(dissipate)
            {
                dissipateTime -= Time.deltaTime;
            }
            if(dissipateTime <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
