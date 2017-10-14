using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrels : MonoBehaviour {

	public float speed;
    private float barrelDir = 1.0f;
	public Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        StartCoroutine(MyCoroutine());
    }



    IEnumerator MyCoroutine()
    {

        yield return new WaitForSeconds(12);
        Destroy(gameObject);


    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
	{

        Vector2 pos = transform.localPosition;
        pos.x += speed * barrelDir;
        transform.localPosition = pos;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.transform.tag == "wallLeft")
        {
            barrelDir = 1.0f;
        }

        if (other.gameObject.tag == "wallRight")
        {
            barrelDir = -1.0f;
        }



    }
}
