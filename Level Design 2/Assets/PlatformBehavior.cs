using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{

    public float timeDelay = 3f;

    float previous = 0f; 

    GameObject[] Zero;
    GameObject[] FortyFive;
    GameObject[] Ninety;
    GameObject[] OneThirtyFive;
    GameObject[] OneEighty;
    GameObject[] TwoTwentyFive;
    GameObject[] TwoSeventy;
    GameObject[] ThreeFifteen;

    bool state = false;
    // Start is called before the first frame update
    void Start()
    {
        Zero = GameObject.FindGameObjectsWithTag("0");
        FortyFive = GameObject.FindGameObjectsWithTag("45");
        Ninety = GameObject.FindGameObjectsWithTag("90");
        OneThirtyFive = GameObject.FindGameObjectsWithTag("135");
        OneEighty = GameObject.FindGameObjectsWithTag("180");
        TwoTwentyFive = GameObject.FindGameObjectsWithTag("225");
        TwoSeventy = GameObject.FindGameObjectsWithTag("270");
        ThreeFifteen = GameObject.FindGameObjectsWithTag("315");
        foreach (GameObject o in Zero) {
            o.SetActive(state);
        }
        foreach (GameObject o in Ninety)
        {
            o.SetActive(state);
        }
        foreach (GameObject o in OneEighty)
        {
            o.SetActive(state);
        }
        foreach (GameObject o in TwoSeventy)
        {
            o.SetActive(state);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("H32O");
        if (Time.time - previous > timeDelay)
        {
            Debug.Log("HO");
            previous = Time.time;
            foreach (GameObject o in Zero)
            {
            o.SetActive(!state);
            }
            foreach (GameObject o in FortyFive)
            {
                o.SetActive(state);
            }
            foreach (GameObject o in Ninety)
            {
                o.SetActive(!state);
            }
            foreach (GameObject o in OneThirtyFive)
            {
                o.SetActive(state);
            }
            foreach (GameObject o in OneEighty)
            {
                o.SetActive(!state);
            }
            foreach (GameObject o in TwoTwentyFive)
            {
                o.SetActive(state);
            }
            foreach (GameObject o in TwoSeventy)
            {
                o.SetActive(!state);
            }
            foreach (GameObject o in ThreeFifteen)
            {
                o.SetActive(state);
            }
            state = !state;
        }
    }
}
