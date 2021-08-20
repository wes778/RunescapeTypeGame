using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingIntro : Quest
{
    //this script want to give seeds and have player get a hoe allowed after build house 
    public Item seedsToGive;
    public Item cornItem;
    bool gaveSeeds;
    public string[] beforeYouCanStartTheQuest;
    public string[] firstTalkToFarmer;
    public string[] afterGettingSeeds;
    public string[] afterFinishedQuest;

    List<Item> corn = new List<Item>();
    
    QuestManager questManager;
    Inventory inventory;
    DialogueManager dialogueManager;
    public SeedStoreManager seedStoreManager;
    public ToolsShopManager toolsShop;
    public Equipment hoeToAddToToolShop;

    private void Start()
    {
        dialogueManager = DialogueManager.Instance;
        questManager = QuestManager.instance;
        inventory = Inventory.instance;
        questManager.inactiveQuests.Add(nameOfQuest);
    }

    public override void Interact()
    {
        if(!questManager.IsQuestFinished("HouseBuilder"))
        {
            dialogueManager.SetDialogue(beforeYouCanStartTheQuest, nameOfQuestGiver);
        } 
        else
        {
            if (!gaveSeeds && !questManager.IsQuestActive(nameOfQuest))
            {
                dialogueManager.SetDialogue(firstTalkToFarmer, nameOfQuestGiver);
                questManager.InactiveToActive(nameOfQuest);
                inventory.Add(seedsToGive);
                inventory.Add(seedsToGive);
                toolsShop.AddTool(hoeToAddToToolShop);
                gaveSeeds = true;
            } 
            else if (inventory.HasItem(cornItem) && questManager.IsQuestActive(nameOfQuest))
            {
                bool hasItem = inventory.HasItem(cornItem);
                while (corn.Count <= 6 && hasItem)
                {
                    //print("In the while loop");
                    print(hasItem);
                    inventory.Remove(cornItem);
                    corn.Add(cornItem);
                    hasItem = inventory.HasItem(cornItem);
                }
                if (corn.Count >= 6)
                {
                    questManager.ActiveToFinsiehd(nameOfQuest);
                    seedStoreManager.AddSeed(seedsToGive);
                    dialogueManager.SetDialogue(afterFinishedQuest, nameOfQuestGiver);
                } 
                else
                {
                    //print("hit else in activeQuest");
                    dialogueManager.SetDialogue(afterGettingSeeds, nameOfQuestGiver);
                }
            }
            else if (questManager.IsQuestFinished(nameOfQuest))
            {
                 //print("Hit else if, if quest is finished");
                 dialogueManager.SetDialogue(afterFinishedQuest, nameOfQuestGiver);
            }
            else
            {
               // print("Hit the last else if the quest is not finished");
                dialogueManager.SetDialogue(afterGettingSeeds, nameOfQuestGiver);
            }

            
        }
       


    }
}
