using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkBehavior : MonoBehaviour
{
    public Transform player;
    public float speed = 10f;
    public Text gameText;

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

        //transform.LookAt(player);
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
        //transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        transform.position = new Vector3(transform.position.x, origY, transform.position.z);


        // }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameText.text = "GAME OVER";
            gameText.gameObject.SetActive(true);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{

    //}
}
