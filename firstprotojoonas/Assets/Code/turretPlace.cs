using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class turretPlace : MonoBehaviour
    {


        [SerializeField]
        private GameObject spawnObject;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void placeTurret()
        {
            Instantiate(spawnObject, transform.position, transform.rotation);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}