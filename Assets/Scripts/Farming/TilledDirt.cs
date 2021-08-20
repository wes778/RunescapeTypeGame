using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilledDirt : Interactable
{
    public Item wateringCan;
    public WateredDirt wateredDirt;
    public Item emptyWateringCan;
    public override void Interact()
    {
        if(Inventory.instance.HasItem(wateringCan))
        {
            Inventory.instance.Remove(wateringCan);
            Inventory.instance.Add(emptyWateringCan);
            Instantiate(wateredDirt, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            
        }
    }
}
