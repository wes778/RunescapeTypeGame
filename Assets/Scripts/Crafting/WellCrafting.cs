using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellCrafting : Interactable
{
    public Transform gameManager;
    List<CraftableItem> craftableItems;
    public Canvas canvasToShow;
    private void Start()
    {
        craftableItems = gameManager.GetComponent<WaterCraftingManager>().craftableItems;
    }

    public override void Interact()
    {
        canvasToShow.GetComponentInChildren<CraftingUI>().UpdateUI(craftableItems);
        canvasToShow.enabled = true;
    }
}
