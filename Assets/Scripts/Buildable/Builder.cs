using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Builder : Interactable
{
    //this is going to be a singleton


    #region Singleton
    public static Builder instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one instance of builder");
            return;
        }
        instance = this;
    }
    #endregion

    
    Queue<Item> itemsCurrentlyInBuilderInventory = new Queue<Item>();
    List<FirstPhaseBuild> firstPhase = new List<FirstPhaseBuild>();
    SecondPhase secondPhase;
    public Item logs;
    Inventory inventory;
    NavMeshAgent meshAgent;
    bool isBuilding;
    Animator animator;
    bool firstPhaseBuilt;
    int buildingsBuilt;
    public Transform builderOriginalPosition;
    private void Start()
    {
        inventory = Inventory.instance;
        meshAgent = GetComponent<NavMeshAgent>();
        isBuilding = false;
        animator = GetComponent<Animator>();
    }

    public void SetFirstPhase(FirstPhaseBuild firstPhase)
    {
        this.firstPhase.Add(firstPhase);
    }

    public override void Interact()
    {
        if (!isBuilding)
        {
            if (!firstPhaseBuilt)
            {
                while (inventory.HasItem(logs))
                {
                    itemsCurrentlyInBuilderInventory.Enqueue(logs);
                    inventory.Remove(logs);
                }
                while (itemsCurrentlyInBuilderInventory.Count > 0 && !firstPhase[buildingsBuilt].itemsNeeded.GetReadyToBuild())
                {
                    itemsCurrentlyInBuilderInventory.Dequeue();
                    firstPhase[buildingsBuilt].itemsNeeded.BuilderAddItems();
                    //print(firstPhase[buildingsBuilt].itemsNeeded.GetReadyToBuild());
                }
                if (buildingsBuilt < firstPhase.Count && firstPhase[buildingsBuilt].itemsNeeded.GetReadyToBuild())
                {
                    print("Went into readyToBuild");
                    meshAgent.SetDestination(firstPhase[buildingsBuilt].moveBuilderHere.position);
                    StartCoroutine(CheckPosition());
                }
            }
            else
            {
                while (inventory.HasItem(logs))
                {
                    itemsCurrentlyInBuilderInventory.Enqueue(logs);
                    inventory.Remove(logs);
                }
                while (itemsCurrentlyInBuilderInventory.Count > 0 && !secondPhase.itemsNeeded.GetReadyToBuild())
                {
                    itemsCurrentlyInBuilderInventory.Dequeue();
                    secondPhase.itemsNeeded.BuilderAddItems();
                }
                if (secondPhase.itemsNeeded.GetReadyToBuild())
                {
                    animator.Play("Hammering");
                    StartCoroutine(Build());
                }
            }
        }
        
        
    }

    
    IEnumerator CheckPosition()
    {
        while (!isBuilding)
        {
            if (!meshAgent.pathPending)
            {
                
                if (meshAgent.remainingDistance <= meshAgent.stoppingDistance)
                {
                   
                   if (!meshAgent.hasPath || meshAgent.velocity.sqrMagnitude == 0f)
                   {
                        
                        isBuilding = true;
                        StopCoroutine(CheckPosition());
                        animator.Play("Hammering");
                        StartCoroutine(Build());
                   }
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }
    

    IEnumerator Build()
    {
        

        if (!firstPhaseBuilt)
        {
            
            yield return new WaitForSeconds(firstPhase[buildingsBuilt].timeToBuild);
            print("We are in the if in build");
            
            secondPhase = Instantiate(firstPhase[buildingsBuilt].secondPhase, firstPhase[buildingsBuilt].transform.position, firstPhase[buildingsBuilt].transform.rotation);
            secondPhase.AddItemsNeeded();
            firstPhase[buildingsBuilt].DestoryThisGameObject();
            isBuilding = false;
            firstPhaseBuilt = true;
            StopCoroutine(Build());
            CheckBuilderInventory();
        } 
        else
        {
            
            yield return new WaitForSeconds(secondPhase.timeToBuild);
            animator.Play("Locomotion");
            Instantiate(secondPhase.finalBuild, secondPhase.transform.position, secondPhase.transform.rotation);
            secondPhase.DestoryThisObject();
            secondPhase = null;
            isBuilding = false;
            buildingsBuilt++;
            firstPhaseBuilt = false;
            meshAgent.SetDestination(builderOriginalPosition.position);
            CheckIfCanBuildAnotherBuilding();
            StopCoroutine(Build());
            
        }
        


    }

    void CheckBuilderInventory()
    {
        while (itemsCurrentlyInBuilderInventory.Count > 0 && !secondPhase.itemsNeeded.GetReadyToBuild())
        {
            itemsCurrentlyInBuilderInventory.Dequeue();
            secondPhase.itemsNeeded.BuilderAddItems();
        }
        if (secondPhase.itemsNeeded.GetReadyToBuild())
        {
            animator.Play("Hammering");
            StartCoroutine(Build());
        } 
        else
        {
            animator.Play("Locomotion");
        }
    }

    void CheckIfCanBuildAnotherBuilding()
    {
        print(buildingsBuilt);
        print(firstPhase.Count);
        if(buildingsBuilt < firstPhase.Count)
        {
            while (itemsCurrentlyInBuilderInventory.Count > 0 && !firstPhase[buildingsBuilt].itemsNeeded.GetReadyToBuild())
            {
                itemsCurrentlyInBuilderInventory.Dequeue();
                firstPhase[buildingsBuilt].itemsNeeded.BuilderAddItems();
                //print(firstPhase[buildingsBuilt].itemsNeeded.GetReadyToBuild());
            }
            if (firstPhase[buildingsBuilt].itemsNeeded.GetReadyToBuild())
            {
                //print("Went into readyToBuild");
                meshAgent.SetDestination(firstPhase[buildingsBuilt].moveBuilderHere.position);
                StartCoroutine(CheckPosition());
            }
        }
        
    }
}
