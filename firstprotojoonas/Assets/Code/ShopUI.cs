using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject placePoints;

        public void DeactivatePlacePoints()
        {
            placePoints.SetActive(false);
        }
    }
}
