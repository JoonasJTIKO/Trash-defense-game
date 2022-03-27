using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }

        // Update is called once per frame
        void Update()
        {
            checkForTrashLeft();
        }

        private void checkForTrashLeft()
        {
            Debug.Log("ASDASD123");
            if (GameObject.FindGameObjectsWithTag("Trash").Length == 0)
            {
                Debug.Log("ASDASD");
                FindObjectOfType<SceneChanger>().LoadNextLevel();
                Destroy(this.gameObject);
            }
        }
    }
}
