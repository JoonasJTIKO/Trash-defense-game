using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class trashManager : MonoBehaviour
    {
        public enum TrashTypeList { Cardboard, Metal, Plastic, Paper, Bio }
        public TrashTypeList trashType;

        private MoneyUI ui;

        [SerializeField]
        private int rewardAmount;

        private AudioSortingScene audio;

        private PlayerMovement playerScript;


        // public PlayerMovement playerObject;

        static bool alreadyAttached = false;
        // Start is called before the first frame update
        void Start()
        {
            audio = GameObject.Find("Audio System").GetComponent<AudioSortingScene>();
            ui = FindObjectOfType<MoneyUI>();
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            //if trash is put in correct bin, speed up player and give money
            if (col.gameObject.tag == this.trashType.ToString())
            {
                ui.AddMoney(rewardAmount);
                playerScript.speed = playerScript.speed * 1.05f;
                audio.playCorrectTrash();
                Destroy(this.gameObject);
            }
            //if tag is player attach to player
            else if (col.gameObject.tag == "Player" && !alreadyAttached)
            {
                playerScript = col.gameObject.GetComponent(typeof(PlayerMovement)) as PlayerMovement;
                this.transform.parent = col.transform;
                playerScript.setChildObject(this.gameObject);
                alreadyAttached = true;
                audio.playPickupTrash();
            }
            //if tag is anything else destroy and do nothing
            else if (col.gameObject.tag != "Trash" && col.gameObject.tag != "Player" && col.gameObject.tag != "Turret")
            {
                Debug.Log("Wrong bin idiot");
                playerScript.removeChildObject();
                audio.playWrongTrash();
                Destroy(this.gameObject);
            }
        }

        void OnDestroy()
        {
            alreadyAttached = false;
        }
    }
}
