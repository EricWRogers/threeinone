using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mTankMovement : MonoBehaviour {
    public float mSpeed;
    public float rSpeed;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");
        //Quaternion rot = transform.localRotation;
        //rot.z -= rotate * rSpeed;
        //transform.localRotation = rot;
        Vector2 pos = transform.localPosition;
        pos.y += move * mSpeed;
        pos.x += rotate * mSpeed;
        transform.localPosition = pos;
        
    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Add velocity to the bullet
        //bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 10;


        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
