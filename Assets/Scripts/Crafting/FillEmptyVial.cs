using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillEmptyVial : Interactable
{
    public Item emptyVial;
    public Item vialFilledWithWater;
    Inventory inventory;
    private void Start()
    {
        inventory = Inventory.instance;
    }
    public override void Interact()
    {
        if(inventory.HasItem(emptyVial))
        {
            FillVial();
        }
    }

    void FillVial()
    {
        inventory.Remove(emptyVial);
        inventory.Add(vialFilledWithWater);
    }
}
