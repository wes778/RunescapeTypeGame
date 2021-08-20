using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPhase : MonoBehaviour
{
    public List<Item> itemsNeededToFinish = new List<Item>();
    //Transform moveBuilderHere;
    public int timeToBuild;
    public ItemsNeededToBuild itemsNeeded;
    public GameObject finalBuild;




    public void AddItemsNeeded()
    {
        itemsNeeded = new ItemsNeededToBuild();
        if (itemsNeeded != null)
        {
            itemsNeeded.AddItems(itemsNeededToFinish);
        }
    }

    public void DestoryThisObject()
    {
        Destroy(this.gameObject);
    }


}
