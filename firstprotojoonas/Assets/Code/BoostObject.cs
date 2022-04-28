using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class BoostObject : MonoBehaviour
    {

        [SerializeField]
        private float boostAmount;
        
        private float playerSpeed;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<PlayerMovement>().startSpeedBoost();
                Destroy(this.gameObject);
            }
        }
    }
}
