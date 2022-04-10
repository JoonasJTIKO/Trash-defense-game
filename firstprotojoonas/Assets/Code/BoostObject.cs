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

            Debug.Log("Edes tämä");
            if (col.gameObject.tag == "Player")
            {
                Debug.Log("asddd111");
                col.gameObject.GetComponent<PlayerMovement>().startSpeedBoost();
                Destroy(this.gameObject);
            }
        }
    }
}
