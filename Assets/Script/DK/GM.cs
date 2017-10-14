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

        //starting wait coroutine
        StartCoroutine(MyCoroutine());

        //MyCoroutine();

        
    }

    IEnumerator MyCoroutine()
    {
        for (int i = 0; i <= 30; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(3);

        }
        
    }

        void FixedUpdate()
	{
		
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
