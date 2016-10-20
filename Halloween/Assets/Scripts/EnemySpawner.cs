using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	GameObject spawnedEnemy;

	bool isSpawnReady = true;

	float spawnDelay = 0.0f;
	float spawnDelayIncrement = 1.0f;
	float spawnDelayCap = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isSpawnReady)
		{
			if (spawnDelay < spawnDelayCap)
			{
				spawnDelay += spawnDelayIncrement;
			}
			else
			{
				GameObject prefab = Resources.Load("Prefabs/Enemy") as GameObject;
				spawnedEnemy = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
				isSpawnReady = false;
				spawnDelay = 0.0f;
			}
		}
		else
		{
			isSpawnReady = !spawnedEnemy;
		}
	}
}
