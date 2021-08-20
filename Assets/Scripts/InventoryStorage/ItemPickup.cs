
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        print("picking up " + item.name);
        if(item.name.Equals("Gold"))
        {
            GoldPickup();
        }
        else
        {
            AnItemPickup();
        }
        
    }
    void GoldPickup()
    {
        print("went into gold pickup");
        Inventory.instance.gold += item.value;
        Destroy(gameObject);
        if(Inventory.instance.onItemChangedCallBack != null)
        {
            Inventory.instance.onItemChangedCallBack.Invoke();
        }
    }

    void AnItemPickup()
    {
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
        {
            
            
            Destroy(gameObject);
        }
    }
}
