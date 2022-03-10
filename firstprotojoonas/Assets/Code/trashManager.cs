using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class trashManager : MonoBehaviour
    {
        public enum TrashTypeList { Cardboard, Bio }
        public TrashTypeList trashType;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == this.trashType.ToString())
            {
                //Lisää massii
                Destroy(this.gameObject);
            }
            else if (col.gameObject.tag == "Player")
            {
                this.transform.parent = col.transform;
            }
            else if (col.gameObject.tag != "Trash")
            {
                //EI Massiii
                Debug.Log("Wrong bin idiot");
                Destroy(this.gameObject);
            }
        }
    }
}
