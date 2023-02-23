using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBehavior : MonoBehaviour
{

    string[] dialogue = new string[4];
    public Text myText;
    int index = 0;


    void Start()
    {
        dialogue[0] = "Ok Ash, your systems should all be online.\nTake a second to test out your visor\nand scrambler gun.";
        dialogue[1] = "Great. Now your job today is to retrieve and\nextract the red ruby of power\nfrom within the vault.";
        dialogue[2] = "Be careful down there, the whole place is\nrigged with advanced defense systems\nthat are set to kill.";
        dialogue[3] = "Use your visor to locate the defenses and\ndisarm them with your scrambler gun.\nYou cannot fail Ash, this is our only chance\nat taking down the glorgons once and for all...";
   
        StartCoroutine("Write", 0);
    }

    void Update()
    {
        if(index == 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            ++index;
            Invoke("NextDialogue", 1.5f);

        }

        if (index == 3) {
            Destroy(gameObject, 10f); 
            DoorBehavior.open = true;
        } 
    }

    void NextDialogue()
    {
        StartCoroutine("Write", index);
    }

    IEnumerator Write(int index)
    {
        for(int i = 0; i < dialogue[index].Length; i++)
        {
            yield return new WaitForSeconds(0.02f);
            myText.text = dialogue[index].Substring(0, i + 1);
        }
        if(this.index < 3 && this.index > 0)
        {
            ++this.index;
            Invoke("NextDialogue", 2f);
        }
    }
}
