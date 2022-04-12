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

        int metalToSpawn;
        [SerializeField]
        public GameObject metalPrefab;

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

        // private GameObject destroyedTrash;

        [SerializeField]
        public GameObject timeOver;

        [SerializeField]
        public TextMeshProUGUI timerText;

        private TrashUI trashUI;
        private int totalTrash;
        private SceneLoader sceneChanger;

        private GameObject sceneChangerObject;

        private SceneLoader sceneLoaderScript;
        private GameObject[] trashList;


        void Awake()
        {
            timeOver.SetActive(false);
        }
        void Start()
        {
            trashUI = FindObjectOfType<TrashUI>();
            cardboardToSpawn = TrashUI.cardboardAmount;
            metalToSpawn = TrashUI.metalAmount;
            plasticToSpawn = TrashUI.plasticAmount;
            paperToSpawn = TrashUI.paperAmount;
            totalTrash = cardboardToSpawn + metalToSpawn + plasticToSpawn + paperToSpawn;
            trashList = new GameObject[totalTrash];
            spawnInterval = sortingTimer / totalTrash;
            sceneChangerObject = GameObject.Find("SceneChanger");
            sceneLoaderScript = sceneChangerObject.GetComponent<SceneLoader>();
            addTrashToList();
            StartCoroutine(spawnTrash());
        }

        private void addTrashToList()
        {
            int x = 0;
            for (int i = 0; i < cardboardToSpawn; i++)
            {
                trashList[x] = cardBoardPrefab;
                x++;
            }
            for (int i = 0; i < metalToSpawn; i++)
            {
                trashList[x] = metalPrefab;
                x++;
            }
            for (int i = 0; i < plasticToSpawn; i++)
            {
                trashList[x] = plasticPrefab;
                x++;
            }
            for (int i = 0; i < paperToSpawn; i++)
            {
                trashList[x] = paperPrefab;
                x++;
            }
        }

        public IEnumerator spawnTrash()
        {
            for (int i = 0; i < trashList.Length; i++)
            {
                Instantiate(trashList[i], new Vector3(Random.Range(-5f, 5f), Random.Range(-3.5f, 3.5f), 1), Quaternion.identity, this.transform);
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        void Update()
        {
            sortingTimer -= Time.deltaTime;
            timerText.SetText(sortingTimer.ToString("F1"));

            if (sortingTimer <= 0.0f)
            {
                timerText.SetText("0.0");
                timeOver.SetActive(true);
                Invoke("startSwapScene", 2.0f);
            }
        }

        private void startSwapScene()
        {
            sceneLoaderScript.swapScene();
        }
    }
}