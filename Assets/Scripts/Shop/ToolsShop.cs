using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsShop : Interactable
{
    public Transform gameManager;
    public Canvas shopCanvas;
    List<Item> itemsInToolShop;
    AllShopsUI shopsUI;
    public CloseShopWhenMoveAway closeShop;

    private void Start()
    {
        itemsInToolShop = gameManager.GetComponent<ToolsShopManager>().items;
        shopsUI = shopCanvas.GetComponentInChildren<AllShopsUI>();
    }

    public override void Interact()
    {
        shopsUI.UpdateUI(itemsInToolShop);
        shopsUI.inShop = true;
        shopCanvas.enabled = true;
        closeShop.SetShopTransform(this.transform);

    }
}
