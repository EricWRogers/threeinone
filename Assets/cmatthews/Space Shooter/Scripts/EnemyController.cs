using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    float timer = 0;

    Vector3 originalPos;

	// Use this for initialization
	void Start () {
        originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        float blah = timer % 3;
        transform.position = originalPos + new Vector3(Mathf.Sin(timer), 0, 0);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            GameManager.killedEnemies++;
        }
    }
}
