using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    float timer = 0;

    Vector3 originalPos;

    public bool isRow1Enemy = false;
    public bool isRow2Enemy = false;
    public bool isRow3Enemy = false;

    public Transform enemy1Gun1;
    public Transform enemy1Gun2;

    Transform enemy2Gun1;
    Transform enemy2Gun2;

    public GameObject bulletPrefab;

    public float bulletForce = 100f;


    // Use this for initialization
    void Start () {
        originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        float blah = timer % 3;
        transform.position = originalPos + new Vector3(Mathf.Sin(timer), 0, 0);

        if (isRow1Enemy)
        {
            int yuck = Random.Range(0, 1000);
            if (yuck == 1)
            {
                GameObject bullet = Instantiate(bulletPrefab, enemy1Gun1.transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(Vector3.down * bulletForce);
            }
            if (yuck == 2)
            {
                GameObject bullet = Instantiate(bulletPrefab, enemy1Gun2.transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(Vector3.down * bulletForce);
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            GameManager.killedEnemies++;

            if(isRow1Enemy)
            {
                GameManager.firstRowEnemiesKilled++;
                Debug.Log(GameManager.firstRowEnemiesKilled + "First Row Killed");
            }
            if (isRow2Enemy)
            {
                GameManager.secondRowEnemiesKilled++;
            }
            if (isRow3Enemy)
            {
                GameManager.thirdRowEnemiesKilled++;
            }
        }
    }
}
