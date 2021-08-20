using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

[CreateAssetMenu(fileName = "New Seed", menuName = "Inventory/Seed")]
public class Seed : Item
{
    public Item cropToGive;
    public StartingCrop startingCrop;
    public int timeToGrow;
    public MiddleCrop middleCrop;
    public FinalCrop finalCrop;
    
    //public Transform playerTransform;
    public override void Use()
    {
        Collider[] objectsAroundPlayer = Physics.OverlapSphere(PlayerTracker.instance.transform.position, .5f);
        for(int i = 0; i < objectsAroundPlayer.Length; i++)
        {
            WateredDirt wateredDirt = objectsAroundPlayer[i].GetComponent<WateredDirt>();
            if(wateredDirt != null)
            {
                if(wateredDirt.GetCurrentSeed() == null)
                {
                    wateredDirt.SetSeed(this);
                    Inventory.instance.Remove(this);
                    break;
                }
            }
        }
    }
}
