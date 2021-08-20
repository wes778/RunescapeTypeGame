using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildHouseQuest : Quest
{
    QuestManager questManager;
    Inventory inventory;
    public int logsNeededToBuildAWall;
    public Item logs;
    public Queue<Item> logsInBuilderInventory = new Queue<Item>();
    public int timeToBuildWall;
    public bool isBuilding;
    NavMeshAgent meshAgent;
    public Transform buildLocation;
    public Transform originalBuilderLoaction;
    Animator animator;
    public HouseBuilding houseBuilding;
    bool hasTalkedTo;
    public string[] firstTimeTalkingToBuilder;
    public string[] dontHaveLogs;
    public Item itemToGive;
    //int logsNeededToFinishHouse;
    public Transform sendBuilderBackToTownPosition;
    public Equipment axeToAddToToolShop;
    public ToolsShopManager toolsShop;
    
    private void Start()
    {
        questManager = QuestManager.instance;
        inventory = Inventory.instance;
        meshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //logsNeededToFinishHouse = houseBuilding.meshRenderers.Length * logsNeededToBuildAWall;
        //questManager.inactiveQuests.Add(this);
    }

    //change this trash
    public override void Interact()
    {
        if (!hasTalkedTo && questManager.IsQuestActive(nameOfQuest))
        {
            DialogueManager.Instance.SetDialogue(firstTimeTalkingToBuilder, nameOfQuestGiver);
            inventory.Add(itemToGive);
            toolsShop.AddTool(axeToAddToToolShop);
            hasTalkedTo = true;
        } 
        //set destination back to town if house is built
        else
        {

            if (!isBuilding && questManager.IsQuestActive(nameOfQuest) && !houseBuilding.GetHouseBuiltStatus())
            {
                if(inventory.HasItem(logs))
                {
                    //Grab logs from inventory
                    while (inventory.HasItem(logs))
                    {
                        logsInBuilderInventory.Enqueue(logs);
                        inventory.Remove(logs);
                    }
                    if (logsInBuilderInventory.Count >= logsNeededToBuildAWall)
                    {
                        WalkBuilderToBuild();
                    }
                } 
                else
                {
                    DialogueManager.Instance.SetDialogue(dontHaveLogs, nameOfQuestGiver);
                }
                
            } 
        }
        
        
    }

    void WalkBuilderToBuild()
    {
        meshAgent.SetDestination(buildLocation.position);
        StartCoroutine(CheckPosition());
        

    }

    IEnumerator CheckPosition()
    {
        while(!isBuilding)
        {
            if (!meshAgent.pathPending)
            {
                if (meshAgent.remainingDistance <= meshAgent.stoppingDistance)
                {
                    if (!meshAgent.hasPath || meshAgent.velocity.sqrMagnitude == 0f)
                    {
                        isBuilding = true;
                        StopCoroutine(CheckPosition());
                        StartCoroutine(BuildHouse());
                    }
                }
            }
            yield return new WaitForSeconds(1f);
        }
        
        


    }
    IEnumerator BuildHouse()
    {
        animator.Play("Hammering");
        while(logsInBuilderInventory.Count >= logsNeededToBuildAWall)
        {
            yield return new WaitForSeconds(timeToBuildWall);
            for (int i = 0; i < logsNeededToBuildAWall; i++)
            {
                logsInBuilderInventory.Dequeue();
            }
            houseBuilding.Build();
            
            if (logsInBuilderInventory.Count <= logsNeededToBuildAWall)
            {
                animator.Play("Locomotion");
                meshAgent.SetDestination(originalBuilderLoaction.position);
                isBuilding = false;
            }
        }
        if (houseBuilding.GetHouseBuiltStatus())
        {
            meshAgent.SetDestination(sendBuilderBackToTownPosition.position);
            questManager.ActiveToFinsiehd(nameOfQuest);
            animator.Play("Locomotion");
        }
        StopCoroutine(BuildHouse());

    }



}
