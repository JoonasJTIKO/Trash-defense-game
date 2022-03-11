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

        public void placeTurret()
        {
            Instantiate(spawnObject, transform.position, transform.rotation);
            Destroy(gameObject);
            ShopUI.SetActive(true);
            ShopUI.GetComponent<ShopUI>().DeactivatePlacePoints();
        }
    }
}