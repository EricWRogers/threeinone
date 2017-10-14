using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float speed;
    //private float barrelDir = 1.0f;
    //public Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(MyCoroutine());

        Vector2 posx = transform.localPosition;
        posx.x += 5.0f * speed;
        transform.localPosition = posx;
    }



    IEnumerator MyCoroutine()
    {

        yield return new WaitForSeconds(12);
        Destroy(gameObject);


    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {

       

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        



    }
}
