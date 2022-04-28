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
        public GameObject cardBoardPrefab1;
        [SerializeField]
        public GameObject cardBoardPrefab2;
        [SerializeField]
        public GameObject cardBoardPrefab3;

        int metalToSpawn;
        [SerializeField]
        public GameObject metalPrefab1;
        [SerializeField]
        public GameObject metalPrefab2;

        int plasticToSpawn;
        [SerializeField]
        public GameObject plasticPrefab;

        int bioToSpawn;
        [SerializeField]
        public GameObject bioPrefab1;
        [SerializeField]
        public GameObject bioPrefab2;

        [SerializeField]
        private float spawnInterval;

        [SerializeField]
        private float sortingTimer = 30f;

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

        //all different trash prefabs
        [SerializeField]
        public GameObject[] allTrashPrefabs;


        void Awake()
        {
            timeOver.SetActive(false);
        }
        void Start()
        {
            //get ui and trahs amount variables from previous scene
            trashUI = FindObjectOfType<TrashUI>();
            cardboardToSpawn = TrashUI.cardboardAmount;
            metalToSpawn = TrashUI.metalAmount;
            plasticToSpawn = TrashUI.plasticAmount;
            bioToSpawn = TrashUI.bioAmount;
            totalTrash = cardboardToSpawn + metalToSpawn + plasticToSpawn + bioToSpawn;
            trashList = new GameObject[totalTrash];
            //set how fast the trash spawn
            spawnInterval = sortingTimer / totalTrash;
            sceneChangerObject = GameObject.Find("SceneChanger");
            sceneLoaderScript = sceneChangerObject.GetComponent<SceneLoader>();
            addTrashToList();
            StartCoroutine(spawnTrash());
        }

        private void addTrashToList()
        {
            for (int i = 0; i < totalTrash; i++)
            {
                trashList[i] = getRandomPrefab();
            }

        }

        //returns random prefab from list
        private GameObject getRandomPrefab()
        {
            return allTrashPrefabs[Random.Range(0, allTrashPrefabs.Length)];
        }

        //instantiate trashprefabs from trashList in random position within set area
        public IEnumerator spawnTrash()
        {
            for (int i = 0; i < trashList.Length; i++)
            {
                Instantiate(trashList[i], new Vector3(Random.Range(-5f, 5f), Random.Range(-3.35f, 3.35f), 1), Quaternion.identity, this.transform);
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