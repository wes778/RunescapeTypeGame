using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class FetchQuest: Quest
{
    public Item itemToGet;
    public Item reward;
    bool isQuestActive;
    bool questFinished;
    bool gaveReward;
    public string[] linesBeforeQuestStarted;
    public string[] questActiveLines;
    public string[] firstFinishedQuest;
    public string[] questFinishedLines;
    QuestManager questManager;
    
   
    private void Start()
    {
        questManager = QuestManager.instance;
        questManager.inactiveQuests.Add(this.nameOfQuest);
        

    }


    public override void Interact()
    {
       
        //check to see if quest is active or finished and do talking lines based on that
        if(!isQuestActive && !questFinished)
        {
            
            DialogueManager.Instance.SetDialogue(linesBeforeQuestStarted, nameOfQuestGiver);
            isQuestActive = true;
            questManager.inactiveQuests.Remove(this.nameOfQuest);
            questManager.activeQuests.Add(this.nameOfQuest);
            
        } 
        else
        {
             DialogueManager.Instance.SetDialogue(questActiveLines, this.nameOfQuestGiver);
        }

        if (isQuestActive && questFinished && gaveReward)
        {
            
            DialogueManager.Instance.SetDialogue(questFinishedLines, this.nameOfQuestGiver);
        }
        if (!questFinished)
        {
            if (Inventory.instance.HasItem(itemToGet))
            {
                Inventory.instance.Remove(itemToGet);
                Inventory.instance.Add(reward);
                questFinished = true;
                gaveReward = true;
                questManager.activeQuests.Remove(this.nameOfQuest);
                questManager.finishedQuests.Add(this.nameOfQuest);
                DialogueManager.Instance.SetDialogue(firstFinishedQuest, this.nameOfQuestGiver);
                
            }
        }
    }

}
