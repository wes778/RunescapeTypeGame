using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillageElder : Interactable
{
    public string questToBeFinished;
    public string nameOfVillager;
    public string[] dialogWhenQuestFinished;
    public string[] dialogIfQuestNotFinished;
    public string[] dialogAfterMovedPosition;
    public string[] dialogAfterBuiltHouse;
    public string[] dialogIfHouseNotBuilt;
    NavMeshAgent meshAgent;
    public Transform positionToMoveNPC;
    public Transform villageElderStartingPos;
    bool hasMoved;
    bool hasTalkedAboutBuildingHouse;

    private void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        QuestManager.instance.inactiveQuests.Add("HouseBuilder");
    }
    public override void Interact()
    {
        if(meshAgent.desiredVelocity.magnitude <= 1)
        {
            if (QuestManager.instance.IsQuestFinished(questToBeFinished) && !hasMoved)
            {
                hasMoved = true;
                QuestManager.instance.activeQuests.Add("HouseBuilder");
                QuestManager.instance.inactiveQuests.Remove("HouseBuilder");
                DialogueManager.Instance.SetDialogue(dialogWhenQuestFinished, nameOfVillager);
                meshAgent.SetDestination(positionToMoveNPC.position);
            }
            else if(hasMoved && QuestManager.instance.IsQuestActive("HouseBuilder"))
            {
                if(!hasTalkedAboutBuildingHouse)
                {
                    hasTalkedAboutBuildingHouse = true;
                    DialogueManager.Instance.SetDialogue(dialogAfterMovedPosition, nameOfVillager);
                    meshAgent.SetDestination(villageElderStartingPos.position);
                } 
               
                else
                {
                    DialogueManager.Instance.SetDialogue(dialogIfHouseNotBuilt, nameOfVillager);
                }
                

            }
            else
            {
                 if (QuestManager.instance.IsQuestFinished("HouseBuilder"))
                {
                    DialogueManager.Instance.SetDialogue(dialogAfterBuiltHouse, nameOfVillager);
                } else
                {
                    DialogueManager.Instance.SetDialogue(dialogIfQuestNotFinished, nameOfVillager);
                }
               
            }

           
        }


        
    }

}
