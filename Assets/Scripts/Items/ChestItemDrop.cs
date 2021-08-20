using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestItemDrop : Interactable
{
    public GameObject openChestToSpawn;
    public List<Item> itemsToDrop = new List<Item>();
    public Transform itemDropZone;

    public override void Interact()
    {
        for(int i = 0; i < itemsToDrop.Count; i++)
        {
            Instantiate(itemsToDrop[i].prefab, itemDropZone.transform.position, itemDropZone.transform.rotation);
        }
        Instantiate(openChestToSpawn, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
        
    }
}
