using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsNeededToBuild
{
    Queue<Item> itemsToNextPhase = new Queue<Item>();
    //Queue<Item> currentHaveItems;
    bool hasEnoughItems;

    public void AddItems(List<Item> itemsNeeded)
    {
        for(int i = 0; i < itemsNeeded.Count; i++)
        {
            itemsToNextPhase.Enqueue(itemsNeeded[i]);
        }
    }

    public void BuilderAddItems()
    {
        if(itemsToNextPhase.Count == 0)
        {
            hasEnoughItems = true;
            return;
        }
        itemsToNextPhase.Dequeue();
        if(itemsToNextPhase.Count == 0)
        {
            hasEnoughItems = true;
        }
    }

    public bool GetReadyToBuild()
    {
        return hasEnoughItems;
    }
}
