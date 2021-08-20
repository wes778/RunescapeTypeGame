using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    public Transform parentTransform;
    //public Transform gameManagerTransform;
    CraftableSlot[] allCraftableSlots;
    //FireCraftingManager fireCraftingManager;
    Canvas canvasToClose;
    private void Start()
    {
        canvasToClose = GetComponentInParent<Canvas>();
        //fireCraftingManager = gameManagerTransform.GetComponent<FireCraftingManager>();
        allCraftableSlots = parentTransform.GetComponentsInChildren<CraftableSlot>();
    }

    public void UpdateUI(List<CraftableItem> craftableItems)
    {
        for (int i = 0; i < allCraftableSlots.Length; i++)
        {
            if (i < craftableItems.Count)
            {
                allCraftableSlots[i].Add(craftableItems[i]);
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
