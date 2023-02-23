using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    public AudioClip pickupSound;

    public int value = 0;

    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Pickup");
            Destroy(gameObject, .5f);
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<PlayerBehavior>().Pickup();
    }
}