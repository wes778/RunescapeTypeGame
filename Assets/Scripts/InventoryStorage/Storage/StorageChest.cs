using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageChest : Interactable
{

    public Canvas storageCanvas;
    public Canvas inventoryCanvas;
    public CloseStorageWhenMoveAway closeStorage;

    public override void Interact()
    {
        if(this.GetComponent<MeshRenderer>().enabled != false)
        {
            YourStorage.instance.isOpen = true;
            storageCanvas.enabled = true;
            inventoryCanvas.enabled = true;
            closeStorage.SetShopTransform(this.transform);
        }
        //print("Interacting with " + tag);
        
    }


    

}
