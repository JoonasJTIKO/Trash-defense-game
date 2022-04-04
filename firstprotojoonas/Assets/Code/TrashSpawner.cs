using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

        [SerializeField]
        private float sortingTimer = 30f;

        private GameObject destroyedTrash;

        [SerializeField]
        public TextMeshProUGUI timeOver;

        [SerializeField]
        public TextMeshProUGUI timerText;

        private TrashUI trashUI;
        private int totalTrash;
        private SceneLoader sceneChanger;

        public GameObject sceneChangerObject;

        private SceneLoader sceneLoaderScript;

        
        void Start()
        {
            trashUI = FindObjectOfType<TrashUI>();
            cardboardToSpawn = TrashUI.cardboardAmount;
            //bioToSpawn = TrashUI.bioAmount;
            plasticToSpawn = TrashUI.plasticAmount;
            paperToSpawn = TrashUI.paperAmount;
            totalTrash = cardboardToSpawn + bioToSpawn + plasticToSpawn + paperToSpawn;
            spawnInterval = sortingTimer / totalTrash;
            sceneChangerObject = GameObject.Find("SceneChanger");
            sceneLoaderScript = sceneChangerObject.GetComponent<SceneLoader>();
            Debug.Log(sceneChangerObject);
            StartCoroutine(spawnTrash());
        }

        public IEnumerator spawnTrash()
        {
            for (int i = 0; i < cardboardToSpawn; i++)
            {
                Instantiate(cardBoardPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 1), Quaternion.identity, this.transform);
                trashUI.reduceByOne("cardboard");
                yield return new WaitForSeconds(spawnInterval);
            }
            for (int i = 0; i < bioToSpawn; i++)
            {
                Instantiate(bioPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 1), Quaternion.identity, this.transform);
                trashUI.reduceByOne("bio");
                yield return new WaitForSeconds(spawnInterval);
            }
            for (int i = 0; i < plasticToSpawn; i++)
            {
                Instantiate(plasticPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 1), Quaternion.identity, this.transform);
                trashUI.reduceByOne("plastic");
                yield return new WaitForSeconds(spawnInterval);
            }
            for (int i = 0; i < paperToSpawn; i++)
            {
                Instantiate(paperPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 1), Quaternion.identity, this.transform);
                trashUI.reduceByOne("paper");
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        void Update()
        {
            Debug.Log(sortingTimer);
            sortingTimer -= Time.deltaTime;
            timerText.SetText(sortingTimer.ToString("F1"));
            

            if (sortingTimer <= 0.0f)
            {
                timerText.SetText("0.0");
                timeOver.IsActive();
                sceneLoaderScript.swapScene();
            }
        }
    }
}
