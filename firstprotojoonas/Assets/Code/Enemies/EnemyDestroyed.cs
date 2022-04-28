using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class EnemyDestroyed : MonoBehaviour
    {
        [SerializeField]
        private float lifetime;

        private Rigidbody2D body;

        void Start()
        {
            body = GetComponent<Rigidbody2D>();
        }

        // will destroy the gameObject after a set time, applies torque aka rotation to the gameObject spinning it
        void Update()
        {
            if(lifetime <= 0)
            {
                Destroy(this.gameObject);
            }
            lifetime -= Time.deltaTime;
            body.AddTorque(1);
        }
    }
}
