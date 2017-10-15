
using UnityEngine;
using System.Collections;

public class CompleteCameraController : MonoBehaviour
{
    public bool playerDead = false;
    public GameObject player = null;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        StartCoroutine(MyCoroutine());
        
    }

    IEnumerator MyCoroutine()
    {
       
            yield return new WaitForSeconds(.5f);

            player = GameObject.FindGameObjectWithTag("Player");
            Vector3 offset = transform.position - player.transform.position;
      

    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 cameraPos = transform.localPosition;
            cameraPos.y = player.transform.position.y + offset.y;
            transform.localPosition = cameraPos;
        }if(playerDead==true)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Vector3 offset = transform.position - player.transform.position;
            playerDead = false;
        }
        
        
    }
}