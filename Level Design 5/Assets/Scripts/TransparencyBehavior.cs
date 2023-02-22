using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyBehavior : MonoBehaviour
{

    private MeshRenderer mr;

    public Material solidMaterial;
    public Material xrayMaterial;

    bool firstTimeXray = true;
    bool firstTimeSolid = true;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.XRAY)
        {
            if(firstTimeXray)
            {
                Invoke("MakeTransparent", 0.6f);
                firstTimeXray = false;
                firstTimeSolid = true;
               
            }
           
        } else
        {
            if (firstTimeSolid)
            {
                Invoke("MakeSolid", 0.6f);
                firstTimeXray = true;
                firstTimeSolid = false;
                
            }
          
        }
    }

    void MakeSolid()
    {
        mr.material = solidMaterial;
    }

    void MakeTransparent()
    {
        mr.material = xrayMaterial;
    }
}
