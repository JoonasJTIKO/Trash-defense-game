using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace towerdefense
{
    public class TrashSpawner : MonoBehaviour
    {
        [SerializeField]
        int cardboardAmount;
        public GameObject cardBoardPrefab;
        [SerializeField]
        int bioAmount;
        public GameObject bioPrefab;

        [SerializeField]
        int plasticAmount;
        public GameObject plasticPrefab;

        [SerializeField]
        int paperAmount;
        public GameObject paperPrefab;
        void Start()
        {
            Invoke("spawnTrash", 0.4f);            
        }

        void spawnTrash()
        {
            for (int i = 0; i < cardboardAmount; i++)
            {
                Instantiate(cardBoardPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 1), Quaternion.identity);
            }
            for (int i = 0; i < bioAmount; i++)
            {
                Instantiate(bioPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 1), Quaternion.identity);
            }
            for (int i = 0; i < plasticAmount; i++)
            {
                Instantiate(plasticPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 1), Quaternion.identity);
            }
            for (int i = 0; i < paperAmount; i++)
            {
                Instantiate(paperPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 1), Quaternion.identity);
            }
        }
    }
}
