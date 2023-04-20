using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    public TextAsset inkFile;
    public TextMeshProUGUI textBox;
    public Button[] choiceButtons;
    public float typingDelay;
    public float lineDelay;
    public TextMeshProUGUI hintText;

    private Story story;
    private float speed;
    private float sens;
    private bool storyMode = false;
    private bool storyFinished = false;
    private bool inTrigger = false;

    void Start()
    {
        story = new Story(inkFile.text);
    }

    private void Update()
    {
        if (inTrigger && Input.GetButtonDown("Submit"))
        {
            hintText.gameObject.SetActive(false);
            StartStoryMode();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hintText.gameObject.SetActive(true);
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
       hintText.gameObject.SetActive(false);
        inTrigger = false;
    }

    private void StartStoryMode()
    {
        storyMode = true;
        speed = FindObjectOfType<PlayerController>().speed;
        FindObjectOfType<PlayerController>().speed = 0;
        sens = FindObjectOfType<MouseLook>().mouseSensitivity;
        FindObjectOfType<MouseLook>().mouseSensitivity = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ContinueStory();
    }

    private void ContinueStory()
    {
        choiceButtons[0].gameObject.SetActive(false);
        choiceButtons[1].gameObject.SetActive(false);
        if (story.canContinue)
        {
            textBox.gameObject.SetActive(true);
            string nextLine = story.Continue();
            StartCoroutine(DisplayText(nextLine));
        }
        else
        {
            FinishDialogue();
        }
    }

    private void ShowChoices()
    {
        List<Choice> choices = story.currentChoices;
        int index = 0;
        foreach (Choice c in choices)
        {
            choiceButtons[index].GetComponentInChildren<TextMeshProUGUI>().text = c.text;
            choiceButtons[index].gameObject.SetActive(true);
            index++;
        }
        for (int i = index; i < 2; i++)
        {
            choiceButtons[i].gameObject.SetActive(false);
        }
    }

    public void SetDecision(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    private void FinishDialogue()
    {
        textBox.gameObject.SetActive(false);
        choiceButtons[0].gameObject.SetActive(false);
        choiceButtons[1].gameObject.SetActive(false);
        FindObjectOfType<PlayerController>().speed = speed;
        FindObjectOfType<MouseLook>().mouseSensitivity = sens;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        storyMode = false;
        storyFinished = true;
    }


    private IEnumerator DisplayText(string text)
    {
        textBox.GetComponent<TextMeshProUGUI>().text = "";

        foreach (char letter in text.ToCharArray())
        {
            textBox.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(typingDelay);
        }
        if(story.currentChoices.Count == 0)
        {
            Invoke("ContinueStory", lineDelay);
        }
        else
        {
            ShowChoices();
        }
    }
}
