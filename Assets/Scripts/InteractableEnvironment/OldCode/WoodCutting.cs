using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutting : Interactable
{
    Equipment equipment;
    Animator animator;
    public Item resourceToGive;
    public GameObject LeftOverObject;
    int timesHit;
    int giveItemTimes;
    private void Start()
    {
        animator = PlayerTracker.instance.playerTransform.GetComponentInChildren<Animator>();
    }

    public override void Interact()
    {
        equipment = EquipmentManager.instance.GetEquipmentInSlot(4);
        print(equipment.name);
        if (equipment.name.Equals("Axe"))
        {
            animator.Play("WoodCutting");
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (equipment.name.Equals("Axe") && animator.GetCurrentAnimatorStateInfo(0).IsName("WoodCutting"))
        {

            timesHit++;
            if (timesHit >= 3)
            {
                timesHit = 0;
                GiveItem();
            }
            print(timesHit);
        }

    }
    void GiveItem()
    {
        giveItemTimes++;
        Inventory.instance.Add(resourceToGive);
        if (giveItemTimes >= 3)
        {
            
            Destroy(this.gameObject);
            Instantiate(LeftOverObject, this.transform.position, this.transform.rotation);
            animator.Play("Locomotion");
        }
    }
}
