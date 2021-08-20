using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;
    new string name = "Ragnar";
    public override void Interact()
    {
        DialogueManager.Instance.SetDialogue(dialogue, name);
    }
}
