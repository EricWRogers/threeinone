using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
	int lives = 3;

	//Enemy
	public GameObject Enemy;
	public int numOfEnemies;
	//SpawnPoint
	//public List<GameObject> Spawners = new List<GameObject>();
	public GameObject[] eSpawners;

	// Use this for initialization
	void Start () {
		AutoFindSpawns();
		//SpawnEnemy();
	}


	void FixedUpdate()
	{
		if(numOfEnemies <= 0)
		{
			SpawnEnemy();
		}
	}

	void AutoFindSpawns()
	{
		//Find All Spawners in level
		//Spawners.AddRange(GameObject.FindGameObjectsWithTag("Spawners"));
		//if (eSpawners == null)
		eSpawners = GameObject.FindGameObjectsWithTag("bSpawners");

	}

	//spawnEnemys it takes the level and give the enemies random stats based on the level number
	void SpawnEnemy()
	{

		foreach (GameObject respawn in eSpawners)
		{
			Instantiate(Enemy, respawn.transform.position, respawn.transform.rotation);
			numOfEnemies++;
		}


	}
}
