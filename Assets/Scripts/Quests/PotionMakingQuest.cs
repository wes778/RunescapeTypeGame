using UnityEngine;

public class PotionMakingQuest : Quest
{
    //fetch red berries and vial of water
    //if you have both of these items then quest is finished and add small potion to crafting
    public CraftableItem smallPotionToAdd;
    public string[] linesBeforeHouseBuilt;
    public string[] startQuestlines;
    public string[] questActiveButDontHaveItemsLines;
    public string[] linesAfterQuestFinished;
    public string[] linesIfYouHaveTheItems;
    public Item[] itemsNeededToCompleteQuest;
    QuestManager questManager;
    Inventory inventory;
    DialogueManager dialogueManager;
    public PotionMakingManager potionManager;
    public BuildableItem buildableCraftingTable;


    private void Start()
    {
        questManager = QuestManager.instance;
        inventory = Inventory.instance;
        dialogueManager = DialogueManager.Instance;
        questManager.inactiveQuests.Add(nameOfQuest);
    }



    public override void Interact()
    {
        if(!questManager.IsQuestFinished("HouseBuilder"))
        {
            dialogueManager.SetDialogue(linesBeforeHouseBuilt, nameOfQuestGiver);
        }
        else
        {
            if(questManager.IsQuestFinished(nameOfQuest))
            {
                dialogueManager.SetDialogue(linesAfterQuestFinished,nameOfQuestGiver);

            }
            else if (questManager.IsQuestActive(nameOfQuest))
            {
                if(inventory.HasAllItems(itemsNeededToCompleteQuest))
                {
                    potionManager.AddCraftablePotion(smallPotionToAdd);
                    questManager.ActiveToFinsiehd(nameOfQuest);
                    dialogueManager.SetDialogue(linesIfYouHaveTheItems, nameOfQuestGiver);
                    inventory.Add(buildableCraftingTable);

                    
                } 
                else
                {
                    dialogueManager.SetDialogue(questActiveButDontHaveItemsLines, nameOfQuestGiver);
                }
            } 
            else
            {
                //first time talking to guy
                dialogueManager.SetDialogue(startQuestlines, nameOfQuestGiver);
                questManager.InactiveToActive(nameOfQuest);
            } 
            
        }
    }
}
