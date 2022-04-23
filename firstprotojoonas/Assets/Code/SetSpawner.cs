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
        
        [SerializeField]
        public int spawnAmount;

        [SerializeField]
        private int maxRounds;

        [SerializeField]
        private bool endless = false;

        public int MaxRounds{ get{ return maxRounds; } }

        public bool Endless{ get{ return endless; } }

        private EnemyCounter counter;

        void Start()
        {
            counter = GetComponent<EnemyCounter>();
        }

        public void SelectSpawner()
        {
            spawnAmount = spawners[index].GetComponent<spawner>().spawnAmount;
            counter.maxEnemyCount = spawnAmount;
            spawners[index].SetActive(true);
            if(index != maxRounds - 1 && !endless)
            {
                index++;
            }
        }
    }
}
