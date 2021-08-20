using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ResourceGathering : Interactable
{
    Equipment equipment;
    Animator animator;
    Inventory inventory;
    public Item resourceToGive;
    public GameObject LeftOverObject;
    int timesHit;
    int giveItemTimes;
    public string animationName;
    public string equipmentNeeded;
    private void Start()
    {
        animator = PlayerTracker.instance.playerTransform.GetComponentInChildren<Animator>();
        inventory = Inventory.instance;
    }

    public override void Interact()
    {
        equipment = EquipmentManager.instance.GetEquipmentInSlot(4);
        //print(equipment.name);
        if (equipment.name.Equals(equipmentNeeded) && !inventory.IsInventoryFull())
        {
            //meshAgent.speed = 0;
            animator.Play(animationName);
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if(equipment != null)
        {
            if (equipment.name.Equals(equipmentNeeded) && animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
            {

                timesHit++;
                if (timesHit >= 3)
                {
                    timesHit = 0;
                    GiveItem();
                }
                //(timesHit);
            }
        }
        

    }
    void GiveItem()
    {
        if(inventory.IsInventoryFull())
        {
            return;
        }
        giveItemTimes++;
        inventory.Add(resourceToGive);
        if (giveItemTimes >= 3)
        {

            Destroy(this.gameObject);
            Instantiate(LeftOverObject, this.transform.position, this.transform.rotation);
            animator.Play("Locomotion");
        }
    }
}
