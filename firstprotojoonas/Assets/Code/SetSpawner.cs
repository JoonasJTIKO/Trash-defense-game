using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class SetSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] spawners;
        private int index = 0;

        public void SelectSpawner()
        {
            spawners[index].SetActive(true);
            index++;
        }
    }
}
