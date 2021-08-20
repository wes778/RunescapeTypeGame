using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMakingManager : MonoBehaviour
{
    public List<CraftableItem> listOfItemsToCraft = new List<CraftableItem>();
    public void AddCraftablePotion(CraftableItem craftableItem)
    {
        listOfItemsToCraft.Add(craftableItem);
    }
}
