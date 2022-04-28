using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject popup;

        [SerializeField]
        private GameObject placePoints;

        // sets placement points inactive, also enables tutorial popup in tutorial level
        public void DeactivatePlacePoints()
        {
            foreach(Transform item in placePoints.transform)
            {
                item.gameObject.SetActive(false);
            }
            if(popup != null)
            {
                popup.SetActive(true);
            }
        }
    }
}
