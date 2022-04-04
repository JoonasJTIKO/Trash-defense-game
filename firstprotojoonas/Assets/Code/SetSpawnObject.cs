using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class SetSpawnObject : MonoBehaviour
    {
        public void setNextSpawn(int number)
        {
            foreach(Transform placePoint in transform)
            {
                if(placePoint != null)
                {
                    placePoint.gameObject.SetActive(true);
                    placePoint.GetComponent<turretPlace>().SetObjectNumber(number);
                }
            }
        }
    }
}
