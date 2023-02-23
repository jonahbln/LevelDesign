using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public Text GameText;
    public string sceneName;
    public static bool pickup = false;
    void Start()
    {
        GameText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pickup()
    {
        GameText.text = "ESCAPE!";
        GameText.gameObject.SetActive(true);
        //GetComponent<CharacterController>().enabled = false;
        pickup = true;
        Invoke("Load", 20f);
    }

    public void Die()
    {
        GameText.text = "YOU DIED!";
        GameText.gameObject.SetActive(true);
        GetComponent<CharacterController>().enabled = false;
        Invoke("Load", 3f);
    }

    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}
