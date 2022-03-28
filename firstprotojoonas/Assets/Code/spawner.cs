using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense 
{
	public class spawner : MonoBehaviour
	{

		[SerializeField, Tooltip("The time after which an object is spawned (in seconds)")]
		private float spawnTime;

		[SerializeField]
		private float initialWait;

		[SerializeField, Tooltip("A random offset for the spawn timer (in seconds)")]
		private float timerOffset;

		[SerializeField, Tooltip("A reference to the prefab we want to create copies from")]
		private GameObject prefab;

		[SerializeField]
		private GameObject parentTest;

		private float timer;

		[SerializeField]
		private int spawnAmount;
		private int originalSpawnAmount;
		private int spawnIndex;

		private GameObject spawnedObject;

		void Start()
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
			originalSpawnAmount++;
			spawnAmount = originalSpawnAmount;
			spawnIndex = spawnAmount - 1;
			timer = initialWait + Random.Range(-timerOffset, timerOffset);
			if(spawnTime > 0)
			{
				Debug.Log("time changed");
				spawnTime = spawnTime - 0.25f;
			}
		}

		private void Spawn()
		{
			spawnedObject = Instantiate(prefab, transform.position, transform.rotation);
			spawnedObject.transform.SetParent(parentTest.transform);
		}
	}
}
