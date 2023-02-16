using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkBehavior : MonoBehaviour
{

    bool active = false;
    public GameObject target;

    void Start()
    {
        target.SetActive(active);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            active = !active;
            target.SetActive(active);
        }
    }
}