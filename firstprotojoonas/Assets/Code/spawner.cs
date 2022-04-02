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

		private int specialIndex = 0;

		private GameObject spawnedObject;

		void Awake()
		{	
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
			originalSpawnAmount = originalSpawnAmount + prefab.Count;
			spawnAmount = originalSpawnAmount;
			spawnIndex = spawnAmount - 1;
			timer = initialWait + Random.Range(-timerOffset, timerOffset);
			if(spawnTime > 0)
			{
				spawnTime = spawnTime - 0.25f;
			}
		}

		private void Spawn()
		{
			if(spawnAmount == originalSpawnAmount - (specialTimes[specialIndex] - 1))
			{
				spawnedObject = Instantiate(specialPrefab[specialIndex], transform.position, transform.rotation);
				spawnedObject.transform.SetParent(parentTest.transform);
				if(specialIndex < specialTimes.Length - 1)
				{
					specialIndex++;
				}
			}
			else
			{
				spawnedObject = Instantiate(prefab[index], transform.position, transform.rotation);
				spawnedObject.transform.SetParent(parentTest.transform);
				index = Random.Range((int)0, (int)prefab.Count);
				Debug.Log(index);
			}
		}
	}
}
