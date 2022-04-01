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
        private GameObject ShopUI;

        [SerializeField]
        private GameObject StartGame;

        private Vector3 turretPos;

        private int objectNumber;

        private GameObject parentObject; // Että saa everythingin alle

        void Start() 
        {
            parentObject = GameObject.Find("Everything");
        }

        public void placeTurret()
        {
            turretPos = new Vector3 (transform.position.x, transform.position.y, 0);
            Instantiate(turretBase, turretPos, transform.rotation, parentObject.transform);
            Instantiate(spawnObject[objectNumber], turretPos, transform.rotation, parentObject.transform);
            ShopUI.SetActive(true);
            StartGame.SetActive(true);
            Destroy(this.gameObject);
            ShopUI.GetComponent<ShopUI>().DeactivatePlacePoints();
        }

        public void SetObjectNumber(int number)
        {
            objectNumber = number;
        }
    }
}