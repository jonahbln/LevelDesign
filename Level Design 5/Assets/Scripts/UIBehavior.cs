using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour
{

    public Text status;

    void Start()
    {
        status.text = "Xray: Off";  
    }

    
    void Update()
    {
        if(PlayerController.XRAY)
        {
            status.text = "Xray: On";
            status.color = Color.green;
        } else
        {
            status.text = "Xray: Off";
            status.color = Color.red;
        }
    }
}
