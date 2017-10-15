using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    // Use this for initialization
    public static int enemies;

    void Start () {

        if (instance == null)
        {
            instance = this;
        }

        enemies = EnemySpawner.enemys.Count;

        Debug.Log(enemies);


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
