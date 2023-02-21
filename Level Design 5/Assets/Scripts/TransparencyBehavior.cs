using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyBehavior : MonoBehaviour
{

    public Material normalMaterial;
    public Material seeThruMaterial;

    private MeshRenderer mr;


    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.XRAY)
        {
            mr.material = seeThruMaterial;
           
        } else
        {
            mr.material = normalMaterial;
        }
    }
}
