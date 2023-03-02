using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 origPosition;
    public Vector3 origRotation;
    public Vector3 flippedPosition;
    public Vector3 flippedRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKey(KeyCode.Space))
        {
            transform.localPosition = flippedPosition;
            transform.localRotation = Quaternion.Euler(flippedRotation);
        }   
     else
        {
            transform.localPosition = origPosition;
            transform.localRotation = Quaternion.Euler(origRotation);
        }
    }
}
