using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public float speed;
	public float jumpForce;
	private Rigidbody2D rb;
	private bool IsGrounded;
	float movehori;
	void Start (){
		rb = GetComponent<Rigidbody2D> ();
		IsGrounded = true; 
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

        Vector2 pos = transform.localPosition;
        pos.x += movehorizontal * speed;
        transform.localPosition = pos;


		//jump
		if (IsGrounded==true){
			if (Input.GetButtonDown ("Jump")) {
				rb.AddForce (new Vector2 (0, jumpForce));
			}
		}if (IsGrounded==false){
			if (Input.GetButtonDown ("Jump")) {
				rb.AddForce (new Vector2 (0, 0));
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.transform.tag == "ground")
		{
			IsGrounded = true;
		}

	}

}
