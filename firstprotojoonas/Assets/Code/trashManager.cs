using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class trashManager : MonoBehaviour
    {
        public enum TrashTypeList { Cardboard, Bio, Plastic, Paper }
        public TrashTypeList trashType;

        private MoneyUI ui;

        [SerializeField]
        private int rewardAmount;

        static bool alreadyAttached = false;
        // Start is called before the first frame update
        void Start()
        {
            ui = FindObjectOfType<MoneyUI>();
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == this.trashType.ToString())
            {
                ui.AddMoney(rewardAmount);
                Destroy(this.gameObject);
            }
            else if (col.gameObject.tag == "Player" && !alreadyAttached)
            {
                this.transform.parent = col.transform;
                alreadyAttached = true;
            }
            else if (col.gameObject.tag != "Trash" && col.gameObject.tag != "Player")
            {
                //EI Massiii
                Debug.Log("Wrong bin idiot");
                Destroy(this.gameObject);
            }
        }

        void OnDestroy()
        {
            alreadyAttached = false;
        }
    }
}
