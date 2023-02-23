using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    public static bool open = false;
    public float doorSpeed = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(open)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(-30, transform.position.y, transform.position.z),
                doorSpeed);
        } 
    }
}
