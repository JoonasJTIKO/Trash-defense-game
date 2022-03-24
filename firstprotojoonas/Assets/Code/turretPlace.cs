using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class turretPlace : MonoBehaviour
    {
        [SerializeField]
        private GameObject spawnObject;

        [SerializeField]
        private GameObject ShopUI;

        [SerializeField]
        List<GameObject> pairPlacePoints = new List<GameObject>();

        private Vector3 turretPos;

        public void placeTurret()
        {
            turretPos = new Vector3 (transform.position.x, transform.position.y, 0);
            Instantiate(spawnObject, turretPos, transform.rotation);
            ShopUI.SetActive(true);
            Destroy(this.gameObject);
            foreach(GameObject placePoint in pairPlacePoints)
            {
                Destroy(placePoint);
            }
            ShopUI.GetComponent<ShopUI>().DeactivatePlacePoints();
        }
    }
}