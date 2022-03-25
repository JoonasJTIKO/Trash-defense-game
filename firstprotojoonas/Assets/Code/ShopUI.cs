using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> placePoints = new List<GameObject>();

        public void DeactivatePlacePoints()
        {
            foreach (GameObject placePointGroup in placePoints)
            {
                if(placePointGroup != null)
                {
                    placePointGroup.SetActive(false);
                }
            } 
        }
    }
}
