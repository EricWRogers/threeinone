using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    // Use this for initialization
    public static int enemies = 0;

    public static int killedEnemies = 0;

    public static int firstRowEnemiesKilled = 0;
    public static int firstRowEnemies = 0;

    public static int secondRowEnemiesKilled = 0;
    public static int secondRowEnemies = 0;

    public static int thirdRowEnemiesKilled = 0;
    public static int thirdRowEnemies = 0;

    void Start () {

        if (instance == null)
        {
            instance = this;
        }

        

        Debug.Log(enemies);


	}
	
	// Update is called once per frame
	void Update () {
		if(killedEnemies == enemies)
        {
            //Game Over!!! you win!
            SceneManager.LoadScene(3);
        }
	}
}
