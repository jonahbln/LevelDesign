using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public static bool stun;
    void Start()
    {
        stun = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = GetComponentInParent<Transform>().localRotation;
        if(Input.GetKey(KeyCode.Mouse0))
        {
            stun = true;
            transform.GetChild(4).gameObject.SetActive(true);
        } 
        else
        {
            stun = false;
            transform.GetChild(4).gameObject.SetActive(false);
        }
    }
}
