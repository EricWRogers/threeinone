using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    Rigidbody body;

    public float speed;

    public float tilt = 3;

    public Transform gun1;
    public Transform gun2;
    public Transform gun3;
    public Transform gun4;

    public GameObject bulletPrefab;
    public float bulletForce = 100f;

    int shotCounter;

    bool dead = false;

    float deathTimer = 0;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (dead)
        {
            deathTimer += Time.deltaTime;
            if (deathTimer == 4)
            {
                SceneManager.LoadScene(3);
            }
        }


        float x = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * x * Time.deltaTime * speed;

        transform.localEulerAngles = Vector3.down * tilt * x;

        if (Input.GetButtonDown("Jump"))
        {

            Debug.Log("TODO: set up an object pool for the bullets so wee dont instantiate a million bullets");
            //Debug.Log(shotCounter % 4);

            if(shotCounter % 4 == 0)
            {
                GameObject bullet = Instantiate(bulletPrefab, gun1.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(Vector3.up * bulletForce);
            }
            else if(shotCounter % 4 == 1)
            {
                GameObject bullet = Instantiate(bulletPrefab, gun2.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(Vector3.up * bulletForce);
            }
            else if(shotCounter % 4 == 2)
            {
                GameObject bullet = Instantiate(bulletPrefab, gun3.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(Vector3.up * bulletForce);
            }
            else if(shotCounter % 4 == 3)
            {
                GameObject bullet = Instantiate(bulletPrefab, gun4.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(Vector3.up * bulletForce);
            }

            shotCounter++;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            //You Lose
            gameObject.SetActive(false);
            dead = true;
        }
    }
}
