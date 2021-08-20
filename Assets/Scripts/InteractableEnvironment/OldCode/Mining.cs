using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : Interactable
{
    Equipment equipment;
    Animator animator;
    public Item resourceToGive;
    public GameObject leftOverItem;
    int timesHit;
    int giveItemTimes;
    private void Start()
    {
        animator = PlayerTracker.instance.playerTransform.GetComponentInChildren<Animator>();
    }

    public override void Interact()
    {
        equipment = EquipmentManager.instance.GetEquipmentInSlot(4);
        if(equipment != null)
        {
            if (equipment.name.Equals("Pick"))
            {
                animator.Play("Mining");
            }
        }
        

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(equipment != null)
        {
            if (equipment.name.CompareTo("Pick") <= 0 && animator.GetCurrentAnimatorStateInfo(0).IsName("Mining"))
            {

                timesHit++;
                if (timesHit >= 3)
                {
                    timesHit = 0;
                    GiveItem();
                }
                //print(timesHit);
            }
        }
        
       
    }
    void GiveItem()
    {
        giveItemTimes++;
        Inventory.instance.Add(resourceToGive);
        if(giveItemTimes >= 3)
        {
            Destroy(this.gameObject);
            Instantiate(leftOverItem, this.transform.position, this.transform.rotation);
            animator.Play("Locomotion");
        }
    }

}
