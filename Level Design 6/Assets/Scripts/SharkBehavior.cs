using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkBehavior : MonoBehaviour
{
    public Transform player;
    public float slow = 10f;
    //public AudioClip enemySFX;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (!LevelManager.gameOver)
        //{
          //  float step = speed * Time.deltaTime;

        float origY = transform.position.y;

        transform.LookAt(player);
        transform.position += transform.forward * (1/slow);
        //transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        transform.position = new Vector3(transform.position.x, origY, transform.position.z);


        // }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //game over
        }
    }
}
