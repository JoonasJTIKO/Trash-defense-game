using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class turretPlace : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> spawnObject = new List<GameObject>();

        [SerializeField]
        private List<float> prices = new List<float>();

        [SerializeField]
        private GameObject turretBase;

        [SerializeField]
        private GameObject usedTurretPoints;

        [SerializeField]
        private GameObject ShopUI;

        [SerializeField]
        private GameObject StartGame;

        private MoneyUI moneyUI;

        private Vector3 turretPos;

        private int objectNumber;

        private GameObject parentObject; // Että saa everythingin alle

        private GameObject placedTurret;

        [SerializeField]
        private GameObject particle;
        
        private RoundStart roundStart;

        void Start() 
        {
            parentObject = GameObject.Find("Everything");
            moneyUI = FindObjectOfType<MoneyUI>();
            roundStart = FindObjectOfType<RoundStart>();
        }

        // will spawn the turret, enable the correct UI elements, take money from the player and disable the placement point
        public void placeTurret()
        {
            turretPos = new Vector3 (transform.position.x, transform.position.y, 0);
            placedTurret = Instantiate(spawnObject[objectNumber], turretPos, transform.rotation, parentObject.transform);
            Instantiate(turretBase, turretPos, transform.rotation, placedTurret.transform);
            ShopUI.SetActive(true);
            if(roundStart.roundStarted == false)
            {
                StartGame.SetActive(true);
            }
            this.gameObject.SetActive(false);
            this.gameObject.transform.SetParent(usedTurretPoints.transform);
            ShopUI.GetComponent<ShopUI>().DeactivatePlacePoints();
            moneyUI.SetMoney(prices[objectNumber]);
            Instantiate(particle, transform.position, transform.rotation);
        }

        // used to determine which turret is to be placed
        public void SetObjectNumber(int number)
        {
            objectNumber = number;
        }
    }
}