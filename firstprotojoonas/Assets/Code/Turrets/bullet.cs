using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class bullet : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.tag == "Enemy")
            {
                Destroy(this.gameObject);
            }
        }
    }
}