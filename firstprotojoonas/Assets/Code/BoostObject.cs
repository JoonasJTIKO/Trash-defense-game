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
                // playerSpeed = col.gameObject.GetComponent<PlayerMovement>().speed;
                // speedBoost();
                Destroy(this);
            }
        }

        // private IEnumerator speedBoost()
        // {
        //     playerSpeed = playerSpeed * 1.4f;
        //     yield return new WaitForSeconds(4.0f);
        //     playerSpeed = playerSpeed / 1.4f;
        //     Debug.Log("Ended :)");
        // }
    }
}
