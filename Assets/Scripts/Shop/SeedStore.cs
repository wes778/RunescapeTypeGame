using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedStore : Interactable
{
    public Transform gameManager;
    public Canvas shopCanvas;
    List<Item> itemsInSeedStore;
    AllShopsUI shopsUI;
    public CloseShopWhenMoveAway closeShop;

    private void Start()
    {
        itemsInSeedStore = gameManager.GetComponent<SeedStoreManager>().items;
        shopsUI = shopCanvas.GetComponentInChildren<AllShopsUI>();
    }

    public override void Interact()
    {
        shopsUI.UpdateUI(itemsInSeedStore);
        shopsUI.inShop = true;
        shopCanvas.enabled = true;
        closeShop.SetShopTransform(this.transform);
    }
}
