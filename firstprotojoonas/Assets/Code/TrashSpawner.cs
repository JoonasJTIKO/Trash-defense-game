using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace towerdefense
{
    public class TrashSpawner : MonoBehaviour
    {
        int cardboardToSpawn;
        [SerializeField]
        public GameObject cardBoardPrefab;

        int bioToSpawn;
        [SerializeField]
        public GameObject bioPrefab;

        int plasticToSpawn;

        [SerializeField]
        public GameObject plasticPrefab;

        int paperToSpawn;

        [SerializeField]
        public GameObject paperPrefab;

        [SerializeField]
        private float spawnInterval;

        private GameObject destroyedTrash;

        private TrashUI trashUI;
        void Start()
        {
            trashUI = FindObjectOfType<TrashUI>();
            cardboardToSpawn = TrashUI.cardboardAmount;
            //bioToSpawn = TrashUI.bioAmount;
            plasticToSpawn = TrashUI.plasticAmount;
            paperToSpawn = TrashUI.paperAmount;
            StartCoroutine(spawnTrash());
        }

        public IEnumerator spawnTrash()
        {
            for (int i = 0; i < cardboardToSpawn; i++)
            {
                Instantiate(cardBoardPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 1), Quaternion.identity);
                trashUI.reduceByOne("cardboard");
                yield return new WaitForSeconds(spawnInterval);
            }
            for (int i = 0; i < bioToSpawn; i++)
            {
                Instantiate(bioPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 1), Quaternion.identity);
                trashUI.reduceByOne("bio");
                yield return new WaitForSeconds(spawnInterval);
            }
            for (int i = 0; i < plasticToSpawn; i++)
            {
                Instantiate(plasticPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 1), Quaternion.identity);
                trashUI.reduceByOne("plastic");
                yield return new WaitForSeconds(spawnInterval);
            }
            for (int i = 0; i < paperToSpawn; i++)
            {
                Instantiate(paperPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 1), Quaternion.identity);
                trashUI.reduceByOne("paper");
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}
