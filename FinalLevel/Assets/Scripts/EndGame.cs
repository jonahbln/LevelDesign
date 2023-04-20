using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI gameText;

    private void OnTriggerEnter(Collider other)
    {
        gameText.gameObject.SetActive(true);
        FindObjectOfType<PlayerController>().speed = 0;
        Invoke("Win", 3f);
    }


    private void Win()
    {
        SceneManager.LoadScene(0);
    }
}