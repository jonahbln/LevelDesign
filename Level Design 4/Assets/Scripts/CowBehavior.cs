using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehavior : MonoBehaviour
{

    public float rotationSpeed = 2f;
    public float walkSpeed = 2f;

    Animator anim;

    bool rotating = false;
    bool walking = false;
    bool eating = false;
    float rotateAmnt;

    float amntRotated = 0;

    float walkDistance = 5f;

    Vector3 walkPos;
    Vector3 startPos;

    float eatTimer = 0;
    

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("Idle", true);

        startPos = transform.position;
    }

   
    void FixedUpdate()
    {
        if(!rotating && !walking && !eating)
        {
            rotating = true;
            eating = false;
            walking = false;
            amntRotated = 0;
            rotateAmnt = Random.Range(30f, 200f);
            
        } else if (rotating)
        {
            if (amntRotated >= rotateAmnt)
            {
                walking = true;
                rotating = false;
                eating = false;
                walkPos = transform.position + transform.forward * walkDistance;

            } else
            {
                amntRotated += rotationSpeed;
                transform.Rotate(Vector3.up * rotationSpeed);
            } 
            
        } else if (walking)
        {
            transform.position = Vector3.MoveTowards(transform.position, walkPos, walkSpeed);
            if(transform.position == startPos)
            {
                walking = false;
                eating = false;
                rotating = false;
            }
            if(transform.position == walkPos)
            {
                walking = false;
                eating = true;
                rotating = false;
                eatTimer = 0;
            }
        } else if (eating)
        {
            eatTimer += Time.deltaTime;
            if(eatTimer >= 3.2f)
            {
                eating = false;
                rotateAmnt = 180f;
                rotating = true;
                walking = false;
                amntRotated = 0;
            }
        }

        anim.SetBool("Idle", rotating);
        anim.SetBool("Walking", walking);
        anim.SetBool("Eating", eating);

    }


}
