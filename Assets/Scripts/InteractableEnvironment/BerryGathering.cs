using UnityEngine;

public class BerryGathering : Interactable
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
        if (equipment == null)
        {
            animator.Play("Gathering");
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (equipment == null && animator.GetCurrentAnimatorStateInfo(0).IsName("Gathering"))
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
    void GiveItem()
    {
        giveItemTimes++;
        Inventory.instance.Add(resourceToGive);
        if (giveItemTimes >= 3)
        {
            Destroy(this.gameObject);
            Instantiate(leftOverItem, this.transform.position, this.transform.rotation);
            animator.Play("Locomotion");
        }
    }
}
