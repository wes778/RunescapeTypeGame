using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Craftable Item", menuName = "CraftableItem/NewCraftableItem")]
public class CraftableItem : ScriptableObject
{
    public Item itemToCraft;
    public Item[] itemsNeededToCraft;

    public void Craft()
    {
        if(Inventory.instance.HasAllItems(itemsNeededToCraft))
        {
            Inventory.instance.Add(itemToCraft);
        }
/*        List<Item> itemsYouHave = new List<Item>();
        //List<int> placeFound = new List<int>();

        for(int i = 0; i < itemsNeededToCraft.Count; i++)
        {
            if(Inventory.instance.hasItem(itemsNeededToCraft[i]))
            {
                itemsYouHave.Add(itemsNeededToCraft[i]);
                Inventory.instance.Remove(itemsNeededToCraft[i]);
            }
        }
        if(itemsNeededToCraft.Count == itemsYouHave.Count)
        {
            Inventory.instance.Add(itemToCraft);
        } 
        else
        {
            for (int i = 0; i < itemsYouHave.Count; i++)
            {
                Inventory.instance.Add(itemsYouHave[i]);
            }
                
        }*/
    }

   /* int CountSameItems(Item item)
    {
        int returnCount = 0;
        for(int i = 0; i < itemsNeededToCraft.Count; i++)
        {
            if(item.Equals(itemsNeededToCraft[i]))
            {
                returnCount++;
            }
        }

        return returnCount;
    }*/
}
