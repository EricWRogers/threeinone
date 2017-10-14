using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
	int lives = 3;
    public GameObject player;
    public GameObject playerSpawn;

	//Enemy
	public GameObject Enemy;
	public int numOfEnemies;
    public int deathCounter = -1;
    public bool playerAlive = false;

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
		if(playerAlive==false)
        {
            Instantiate(player, playerSpawn.transform.position, playerSpawn.transform.rotation);
            deathCounter++;
            playerAlive = true;
        }
	}

	void AutoFindSpawns()
	{
		
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
