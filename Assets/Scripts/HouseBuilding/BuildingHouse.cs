using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHouse : Interactable
{
    public List<Item> logs = new List<Item>();
    public Item log;
    public Animator animator;
    public HouseBuilding houseBuilding;
    public int whenToBuildWallCount;
    public int logsItTakesToBuildWall;
    EquipmentManager equipmentManager;
    Inventory inventory;


    private void Start()
    {
        equipmentManager = EquipmentManager.instance;
        inventory = Inventory.instance;
        whenToBuildWallCount = 1;
    }

    public override void Interact()
    {
        if(houseBuilding.GetHouseBuiltStatus())
        {
            this.gameObject.GetComponent<BuildingHouse>().enabled = false;
        }
        if(houseBuilding.GetHouseBuiltStatus())
        {
            animator.Play("Locomotion");
        }
        if(equipmentManager.currentEquipment[4] != null && equipmentManager.currentEquipment[4].name.Equals("Hammer") && houseBuilding.GetHouseBuiltStatus() == false)
        {
            animator.Play("Hammering");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Hammering") && equipmentManager.currentEquipment[4].name.Equals("Hammer"))
        {
            if (inventory.HasItem(log) && houseBuilding.GetHouseBuiltStatus() == false)
            {
                AddLogs();
            }
        }
        
    }

    void AddLogs()
    {
        //if logs found in inventory remove from inventory and add to logs list
        //if logs list has count 
        logs.Add(log);
        inventory.Remove(log);
        if(logs.Count >= whenToBuildWallCount)
        {
            houseBuilding.Build();
            whenToBuildWallCount += logsItTakesToBuildWall;
        }
    }
}
