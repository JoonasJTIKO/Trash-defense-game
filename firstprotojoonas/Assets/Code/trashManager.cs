using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class trashManager : MonoBehaviour
    {
        public enum TrashTypeList { Cardboard, Bio }
        public TrashTypeList trashType;

        private MoneyUI ui;
        // Start is called before the first frame update
        void Start()
        {
            ui = FindObjectOfType<MoneyUI>();
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == this.trashType.ToString())
            {
                ui.AddMoney(50);
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
