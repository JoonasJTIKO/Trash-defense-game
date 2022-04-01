using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class SetSpawnObject : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> placePoints = new List<GameObject>();

        public void setNextSpawn(int number)
        {
            foreach(GameObject placePoint in placePoints)
            {
                if(placePoint != null)
                {
                    placePoint.GetComponent<turretPlace>().SetObjectNumber(number);
                }
            }
        }
    }
}
