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

    Vector3 initialRotation;
    void Start()
    {
        innerLaser = transform.GetChild(2);
        outerLaser = transform.GetChild(3);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialRotation = transform.localRotation.eulerAngles;
    }


    void FixedUpdate()
    {
        transform.LookAt(player);

        RaycastHit hit;
        Ray r = new Ray(innerLaser.position, transform.forward);

        if (Physics.Raycast(r, out hit, range))
        {
            if(hit.collider.CompareTag("Player") && canFire)
            {
                canFire = false;
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

        RaycastHit hit;
        Ray r = new Ray(innerLaser.position, transform.forward);

        if (Physics.Raycast(r, out hit, range))
        {
            if (hit.collider.CompareTag("Player"))
            {
                FindObjectOfType<PlayerBehavior>().Die();
            }
        }

        Invoke("changeFire", .5f);
    }

    void changeFire()
    {
        outerLaser.GetComponent<MeshRenderer>().enabled = false;
        canFire = !canFire;
    }
}