using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class bullet : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            Destroy(this.gameObject);
        }
    }
}