using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense 
{
	public class spawner : MonoBehaviour
	{

		[SerializeField]
		private float spawnTime;

		[SerializeField]
		private float initialWait;

		[SerializeField]
		private float timerOffset;

		[SerializeField]
		private List<GameObject> prefab = new List<GameObject>();

		[SerializeField]
		private GameObject parentTest;

		private float timer;

		private int index = 0;
		public int spawnAmount;
		private int originalSpawnAmount;
		private int spawnIndex;

		[SerializeField]
		private GameObject[] specialPrefab;

		[SerializeField]
		private int[] specialTimes;

		[SerializeField, Tooltip("use to determine the time between special spawns in endless mode")]
		private int specialTime = 5;

		private int specialIndex = 0;

		private GameObject spawnedObject;

		[SerializeField, Tooltip("how many more enemies to be spawned each round")]
		private int roundIncrease = 0;

		private SetSpawner setSpawner;
		private int originalSpecialTime;

		void Start()
		{
			setSpawner = GetComponentInParent<SetSpawner>();
		}
		void Awake()
		{	
			originalSpecialTime = specialTime;
			originalSpawnAmount = spawnAmount;
			spawnIndex = spawnAmount - 1;
			timer = initialWait + Random.Range(-timerOffset, timerOffset);
		}

		void Update()
		{
			if (timer <= 0) return;

			timer -= Time.deltaTime;

			if (timer <= 0)
			{
				Spawn();
				spawnAmount--;
				if(spawnIndex > 0)
				{
					timer = spawnTime + Random.Range(-timerOffset, timerOffset);
					spawnIndex--;
				}
				else if(spawnIndex == 0)
				{
					gameObject.SetActive(false);
				}
			}
		}

		private void OnValidate()
		{
			if (timerOffset > spawnTime)
			{
				timerOffset = spawnTime;
			}
		}

		private void OnDisable()
		{
			spawnAmount = originalSpawnAmount + roundIncrease;
			originalSpawnAmount = spawnAmount;
			spawnIndex = spawnAmount - 1;
			timer = initialWait + Random.Range(-timerOffset, timerOffset);
			if(spawnTime > 0.3F)
			{
				spawnTime = spawnTime - 0.1f;
			}
			specialTime = originalSpecialTime;
		}

		private void Spawn()
		{
			if(!setSpawner.Endless && spawnAmount == originalSpawnAmount - (specialTimes[specialIndex] - 1))
			{
				spawnedObject = Instantiate(specialPrefab[specialIndex], transform.position, transform.rotation);
				spawnedObject.transform.SetParent(parentTest.transform);
				if(specialIndex < specialTimes.Length - 1)
				{
					specialIndex++;
				}
			}
			else if(setSpawner.Endless && spawnAmount == originalSpawnAmount - (specialTime - 1))
			{
				spawnedObject = Instantiate(specialPrefab[specialIndex], transform.position, transform.rotation);
				spawnedObject.transform.SetParent(parentTest.transform);
				if(specialIndex < specialPrefab.Length - 1)
				{
					specialIndex++;
				}
				else if(specialIndex == specialPrefab.Length - 1)
				{
					specialIndex = 0;
				}
				specialTime += originalSpecialTime;
			}
			else
			{
				spawnedObject = Instantiate(prefab[index], transform.position, transform.rotation);
				spawnedObject.transform.SetParent(parentTest.transform);
				index = Random.Range((int)0, (int)prefab.Count);
			}
		}
	}
}
