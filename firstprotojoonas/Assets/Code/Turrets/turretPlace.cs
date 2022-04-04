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
        private GameObject turretBase;

        [SerializeField]
        private GameObject usedTurretPoints;

        [SerializeField]
        private GameObject ShopUI;

        [SerializeField]
        private GameObject StartGame;

        private Vector3 turretPos;

        private int objectNumber;

        private GameObject parentObject; // Että saa everythingin alle

        private GameObject placedTurret;

        void Start() 
        {
            parentObject = GameObject.Find("Everything");
        }

        public void placeTurret()
        {
            turretPos = new Vector3 (transform.position.x, transform.position.y, 0);
            placedTurret = Instantiate(spawnObject[objectNumber], turretPos, transform.rotation, parentObject.transform);
            Instantiate(turretBase, turretPos, transform.rotation, placedTurret.transform);
            ShopUI.SetActive(true);
            StartGame.SetActive(true);
            this.gameObject.SetActive(false);
            this.gameObject.transform.SetParent(usedTurretPoints.transform);
            ShopUI.GetComponent<ShopUI>().DeactivatePlacePoints();
        }

        public void SetObjectNumber(int number)
        {
            objectNumber = number;
        }
    }
}