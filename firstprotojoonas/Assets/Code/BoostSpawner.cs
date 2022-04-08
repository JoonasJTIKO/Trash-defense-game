using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class BoostSpawner : MonoBehaviour
    {
        private float spawnTime;

        [SerializeField]
        public GameObject speedBoostPrefab;


        void Start()
        {
            spawnTime = Random.Range(2f,10f);
            StartCoroutine(spawnBoost());
        }

        public IEnumerator spawnBoost()
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(speedBoostPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 1), Quaternion.identity, this.transform);
        }
    }
}
