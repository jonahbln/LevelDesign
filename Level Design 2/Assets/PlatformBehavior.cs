using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{

    public float timeDelay = 2.5f;
    public float scale = .005f;

    private float time;

    float previous = 0f; 

    GameObject[] Zero;
    GameObject[] FortyFive;
    GameObject[] Ninety;
    GameObject[] OneThirtyFive;
    GameObject[] OneEighty;
    GameObject[] TwoTwentyFive;
    GameObject[] TwoSeventy;
    GameObject[] ThreeFifteen;

    GameObject player;

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
        player = GameObject.FindGameObjectWithTag("Player");
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
        time = timeDelay;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("H32O");
        if (Time.time - previous > time)
        {
            Debug.Log("HO");
            previous = Time.time;
            foreach (GameObject o in Zero)
            {
            o.SetActive(!state);
            }
            foreach (GameObject o in Ninety)
            {
                o.SetActive(!state);
            }
            foreach (GameObject o in OneEighty)
            {
                o.SetActive(!state);
            }
            foreach (GameObject o in TwoSeventy)
            {
                o.SetActive(!state);
            }
            state = !state;
            
            time = timeDelay - (scale * player.transform.position.y);
        }
    }
}
