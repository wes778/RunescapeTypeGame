using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorStore : Interactable
{
    public Transform gameManager;
    public Canvas shopCanvas;
    List<Item> itemsInArmorStore;
    AllShopsUI shopsUI;
    public CloseShopWhenMoveAway closeShop;

    private void Start()
    {
        itemsInArmorStore = gameManager.GetComponent<ArmorStoreManager>().items;
        shopsUI = shopCanvas.GetComponentInChildren<AllShopsUI>();
    }

    public override void Interact()
    {
        shopsUI.UpdateUI(itemsInArmorStore);
        shopsUI.inShop = true;
        shopCanvas.enabled = true;
        closeShop.SetShopTransform(this.transform);

    }
}
