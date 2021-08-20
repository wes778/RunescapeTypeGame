using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMakingUI : MonoBehaviour
{
    public Transform parentTransform;
    public Transform gameManagerTransform;
    CraftableSlot[] allCraftableSlots;
    PotionMakingManager fireCraftingManager;
    Canvas canvasToClose;
    private void Start()
    {
        canvasToClose = GetComponentInParent<Canvas>();
        fireCraftingManager = gameManagerTransform.GetComponent<PotionMakingManager>();
        allCraftableSlots = parentTransform.GetComponentsInChildren<CraftableSlot>();
    }

    public void UpdateUI()
    {
        for(int i = 0; i < allCraftableSlots.Length; i++)
        {
            if(i < fireCraftingManager.listOfItemsToCraft.Count)
            {
                allCraftableSlots[i].Add(fireCraftingManager.listOfItemsToCraft[i]);
            }
            else
            {
                allCraftableSlots[i].Remove();
            }
        }
    }
    public void CloseCanvas()
    {
        canvasToClose.enabled = false;
    }
}
