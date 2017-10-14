using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public float speed;
	public float jumpForce;
	private Rigidbody2D rb;
	private bool IsGrounded;
    private bool CanClimb;
	private float movehori;
    public GM gameloop;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;



    void Start (){
		rb = GetComponent<Rigidbody2D> ();
		IsGrounded = true; 
	}
    private void Awake()
    {
        gameloop = GameObject.Find("GM").GetComponent<GM>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(bulletPrefab,bulletSpawn.position,bulletSpawn.rotation);

        // Add velocity to the bullet
        //bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 10;

      
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    void FixedUpdate()
	{
        //move
        //if (Input.GetAxis ("Horizontal") >= 1) {
        //	float movehori = 1;
        //}else if(Input.GetAxis ("Horizontal") <= 1) {
        //	float movehori = -1;
        //}
        //float movehori = Input.GetAxis ("Horizontal");
        //Vector2 movement = new Vector2 (movehori, 0.0f);
        //rb.velocity = rb.velocity + movement * velo;
        float movehorizontal = Input.GetAxis("Horizontal");
        Vector2 posy = transform.localPosition;
        Vector2 posx = transform.localPosition;
        posx.x += movehorizontal * speed;
        transform.localPosition = posx;


		//jump
		if (IsGrounded==true){
			if (Input.GetButtonDown ("Jump")) {
                posy.y += jumpForce * speed;
                transform.localPosition = posy;
                IsGrounded = false;
			}
		}if (CanClimb==true){
			if (Input.GetButtonDown ("Climb")) {
                posy.y += 15.0f * speed;
                transform.localPosition = posy;
                CanClimb = false;
			}
		}

	}

	void OnCollisionEnter2D(Collision2D other)
	{
        Debug.Log(other.gameObject.tag);
        if (other.transform.tag == "ground")
		{
			IsGrounded = true;
		}
        
        if(other.gameObject.tag == "barrel")
        {
            //Destroy(other.collider.gameObject);
            gameloop.playerAlive = false;
            Destroy(gameObject);
        }

        

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lader")
        {
            CanClimb = true;

        }
    }


}
