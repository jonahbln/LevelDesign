using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prisonerController : MonoBehaviour
{

    public GameObject player;
    // S
    // tart is called before the first frame update
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }
}
