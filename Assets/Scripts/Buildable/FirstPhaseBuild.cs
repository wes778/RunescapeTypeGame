using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPhaseBuild : MonoBehaviour
{
    public List<Item> itemsNeededToFinish = new List<Item>();
    public Transform moveBuilderHere;
    public int timeToBuild;
    public ItemsNeededToBuild itemsNeeded;
    public SecondPhase secondPhase;

    private void Start()
    {
        itemsNeeded = new ItemsNeededToBuild();
        if(itemsNeeded != null)
        {
            itemsNeeded.AddItems(itemsNeededToFinish);
        }
        Builder.instance.SetFirstPhase(this);

    }

    public void DestoryThisGameObject()
    {
        Destroy(this.gameObject);
    }

}
