using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Buildable", menuName = "Inventory/Buildable")]
public class BuildableItem : Item
{
    public GameObject startOfBuild;
    public Vector3 offset;

    public override void Use()
    {
        if(PlayerTracker.instance.GetComponent<PlayerController>().GetBuildableGameObjectNull())
        {
            GameObject testing = Instantiate(prefab, PlayerTracker.instance.transform.position, PlayerTracker.instance.transform.rotation);
            PlayerTracker.instance.GetComponent<PlayerController>().SetBuildableItem(testing, this, offset);
            Inventory.instance.Remove(this);
        }
    }
}
