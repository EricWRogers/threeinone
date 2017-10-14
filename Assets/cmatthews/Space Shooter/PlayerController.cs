using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody body;

    public float speed;
    


    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * x * Time.deltaTime * speed;
	}
}
