using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Starting fight...");
        if (other.gameObject.tag.Equals("Player")) BossBehavior.startFight = true;
    }
}
