using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject prefab;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;

    Camera c;

    public int rows = 5;
    public int columns = 10;

    public float edgePadding = 0.1f;
    public float bottomPadding = 0.4f;

    public static List<GameObject> enemys = new List<GameObject>();

    private void Awake()
    {
        c = Camera.main;
        CreateEnemys();
    }

    // Use this for initialization
    void Start ()
    {
        int pixelheight = c.pixelHeight;
        int pixelwidth = c.pixelWidth;
        Debug.Log(pixelheight);
        Debug.Log(c.ScreenToWorldPoint(new Vector3(0, pixelheight, 10)));



        //Vector3 blah = c.ScreenToWorldPoint(new Vector3(pixelwidth / 2, pixelheight / 2, 10));

        //Instantiate(prefab, blah, Quaternion.identity);

        




	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateEnemys()
    {
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(edgePadding, bottomPadding, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1 - edgePadding, 1 - edgePadding, 0));

        bottomLeft.z = 0;

        float w = (topRight.x - bottomLeft.x) / (float)columns;
        float h = (topRight.y - bottomLeft.y) / (float)rows;


        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (row == 0)
                {
                    GameObject enemy = Instantiate(prefab);
                    enemy.transform.position = bottomLeft + new Vector3((col + .5f) * w, (row + .5f) * h, 0);
                    //do other stuff to brick
                    enemys.Add(enemy);

                    GameManager.enemies++;
                }

                if (row == 1)
                {
                    GameObject enemy = Instantiate(prefab2);
                    enemy.transform.position = bottomLeft + new Vector3((col + .5f) * w, (row + .5f) * h, 0);
                    //do other stuff to brick
                    enemys.Add(enemy);
                    GameManager.enemies++;
                }

                if (row == 2)
                {
                    GameObject enemy = Instantiate(prefab3);
                    enemy.transform.position = bottomLeft + new Vector3((col + .5f) * w, (row + .5f) * h, 0);
                    //do other stuff to brick
                    enemys.Add(enemy);
                    GameManager.enemies++;
                }


            }
        }
    }
}
