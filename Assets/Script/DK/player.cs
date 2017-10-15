using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {
	public float speed;
	public float jumpForce;
	private Rigidbody rb;
	private bool IsGrounded;
    private bool CanClimb;
	private float movehori;
    private int damage = 0;
    public GM gameloop;
    public CompleteCameraController CCC;
    private int cout;
    private bool isClimbing = false;
    private bool beatLevel2 = true;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;



    void Start (){
		rb = GetComponent<Rigidbody> ();
		IsGrounded = true; 
	}
    private void Awake()
    {
        gameloop = GameObject.Find("GM").GetComponent<GM>();
        CCC = GameObject.Find("MainCamera").GetComponent<CompleteCameraController>();
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
			//if (Input.GetButtonDown ("Jump")) {
            //    posy.y += jumpForce * speed;
            //    transform.localPosition = posy;
            //    IsGrounded = false;
			//}
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector3(0, 5, 0);
                //SceneManager.LoadScene("SpaceShooterScene", LoadSceneMode.Single);
                IsGrounded = false;
            }
            
		}
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        if (Input.GetButtonDown("Climb"))
        {
            isClimbing = true;
        }
        if (Input.GetButtonUp("Climb"))
        {
            isClimbing = false;
        }
		if(CanClimb==true && isClimbing==true)
        {
            rb.velocity = new Vector3(0, 5, 0);
        }

	}

	void OnCollisionEnter(Collision other)
	{
        Debug.Log(other.gameObject.tag);
        if (other.transform.tag == "ground")
		{
			IsGrounded = true;
		}
        
        if(other.gameObject.tag == "barrel")
        {
            damage++;
            //Destroy(other.collider.gameObject);
            if (damage == 2)
            {
                gameloop.playerAlive = false;
                CCC.playerDead = true;
                Destroy(gameObject);
            }
            else
            {
                Destroy(other.collider.gameObject);
            }
            
        }

        if (other.gameObject.tag == "out")
        {
            SceneManager.LoadScene("SpaceShootScene", LoadSceneMode.Single);
        }

        if (other.gameObject.tag == "health")
        {
            if (other.gameObject.tag == "health")
            {

                damage--;
                Destroy(other.collider.gameObject);

            }
        }



    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "lader")
        {
            CanClimb = true;

        }
        if(collision.gameObject.tag == "out")
        {
            SceneManager.LoadScene("SpaceShooterScene", LoadSceneMode.Single);
        }
        if (collision.gameObject.tag == "out")
        {
            SceneManager.LoadScene("SpaceShooterScene", LoadSceneMode.Single);
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "lader")
        {
            CanClimb = false;

        }
    }


}
