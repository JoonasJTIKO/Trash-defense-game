using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense 
{
	public class spawner : MonoBehaviour
	{

		[SerializeField, Tooltip("The time after which an object is spawned (in seconds)")]
		private float spawnTime;

		[SerializeField, Tooltip("A random offset for the spawn timer (in seconds)")]
		private float timerOffset;

		[SerializeField, Tooltip("A reference to the prefab we want to create copies from")]
		private GameObject prefab;

		private float timer;

		[SerializeField]
		private int spawnAmount;
		private int spawnIndex;

		private GameObject spawnedObject;

		void Start()
		{	
			spawnIndex = spawnAmount - 1;
			timer = spawnTime + Random.Range(-timerOffset, timerOffset);
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

		private void DoDestroy()
		{
			Destroy(spawnedObject);
			spawnedObject = null;
		}

		private void OnValidate()
		{
			if (timerOffset > spawnTime)
			{
				timerOffset = spawnTime;
			}
		}

		private void Spawn()
		{
			spawnedObject = Instantiate(prefab, transform.position, transform.rotation);
		}
	}
}
