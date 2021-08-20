using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager Instance;
    string[] allDialogue;
    public GameObject dialoguePanel;
    Text dialogueText, nameText;
    Button dialogueButton;
    int currentDialogueIndex;


    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(Instance);
        } 
        else
        {
            Instance = this;
        }
        dialoguePanel.SetActive(false);
    }

    private void Start()
    {
        dialogueText = dialoguePanel.transform.Find("DialogueText").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("NameText").GetComponent<Text>();
        dialogueButton = dialoguePanel.transform.Find("DialogueButton").GetComponent<Button>();
        dialogueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        
    }

    public void SetDialogue(string[] dialogue, string name)
    {
        currentDialogueIndex = 0;
        allDialogue = dialogue;
        nameText.text = name;
        dialoguePanel.SetActive(true);
        ChangeText();
    }
    public void ChangeText()
    {
        dialogueText.text = allDialogue[currentDialogueIndex];
    }

    void ContinueDialogue()
    {
        if(currentDialogueIndex < allDialogue.Length - 1)
        {
            currentDialogueIndex++;
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
        ChangeText();
        
    }

}
