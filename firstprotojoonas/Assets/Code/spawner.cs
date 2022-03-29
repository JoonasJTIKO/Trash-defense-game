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

		private GameObject spawnedObject;

		void Start()
		{	
			spawnAmount = spawnAmount * prefab.Count;
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
			spawnedObject = Instantiate(prefab[index], transform.position, transform.rotation);
			spawnedObject.transform.SetParent(parentTest.transform);
			if(index < prefab.Count - 1)
			{
				index++;
			}
			else if(index == prefab.Count - 1)
			{
				index = 0;
			}
			else
			{
				Debug.Log("spawn index broke lol");
			}
		}
	}
}
