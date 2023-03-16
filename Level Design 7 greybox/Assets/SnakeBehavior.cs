using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehavior : MonoBehaviour
{

    Rigidbody rb;
    public float moveSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 15f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * moveSpeed);
        transform.Rotate(0f, 1f, 0f);
    }
}
