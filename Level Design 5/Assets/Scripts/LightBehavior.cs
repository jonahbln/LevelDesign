using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour
{
    public float random;
    public float flicker;
    public Color escapeColor;
    bool first = true;
    void Start()
    {
        if(random == 0)
        {
            random = Random.value * 15;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time % 15 > random - 1 && Time.time % 15 < random + 1 && first)
        {
            flick();
        }
        if(PlayerBehavior.pickup == true)
        {
            GetComponent<Light>().color = escapeColor;
        }
    }

    void flick()
    {
        first = false;
        GetComponent<Light>().intensity -= flicker;
        GetComponent<Light>().range -= flicker;
        Invoke("flock", .75f);
    }

    void flock()
    {
        GetComponent<Light>().intensity += flicker;
        GetComponent<Light>().range += flicker;
        first = true;
    }
}
