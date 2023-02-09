using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    Transform player;
    Vector3 targetPos;
    public float moveSpeed = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        targetPos = new Vector3(player.position.x, player.position.y, player.position.z);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        if (transform.position == targetPos) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) Destroy(gameObject); 
    }
}
