using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCrop : Interactable
{
    Seed currentCropSeed;
    public DirtToBeTilled dirtToBeTilled;
    public void SetCurrentCropSeed(Seed currentSeed)
    {
        currentCropSeed = currentSeed;
    }

    public override void Interact()
    {
        Inventory.instance.Add(currentCropSeed.cropToGive);
        
        WateredDirt wd = GetComponentInParent<WateredDirt>();
        wd.DecreaseCropCount();
        if(wd.GetCurrentCropCount() <= 0)
        {
            Instantiate(dirtToBeTilled, wd.transform.position, wd.transform.rotation);
            Destroy(wd.gameObject);
        }

        Destroy(this.gameObject);
    }
}
