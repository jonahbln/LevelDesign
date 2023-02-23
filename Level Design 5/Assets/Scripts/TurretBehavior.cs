using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    public float range = 4f;

    bool canFire = true;

    Transform innerLaser;
    Transform outerLaser;
    Transform player;
    float initialTime;
    void Start()
    {
        innerLaser = transform.GetChild(2);
        outerLaser = transform.GetChild(3);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void FixedUpdate()
    {
        transform.LookAt(player);
        RaycastHit hit;
        Ray r = new Ray(innerLaser.position, transform.forward);

        if (Physics.Raycast(r, out hit, range))
        {
            if(hit.collider.CompareTag("Wall")) 
            {
                canFire = false;
            }
            else
            {
                canFire = true;
            }
            if(hit.collider.CompareTag("Player") && canFire)
            {
                Invoke("Fire", 0.5f);
            }
            else
            {
                outerLaser.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    void Fire()
    {
        outerLaser.GetComponent<MeshRenderer>().enabled = true;
        //canFire = false;

        // !!!!!
        // DONT MESS WITH THIS YOU WILL CRASH UNITY AND LOSE ALL YOUR WORK
        // !!!!!
        //initialTime = Time.time;
        //while (Time.time - initialTime <= 2f)
        //{

        //}
        // outerLaser.GetComponent<MeshRenderer>().enabled = false;
        //canFire = true;
    }
}