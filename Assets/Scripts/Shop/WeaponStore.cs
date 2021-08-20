using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStore : Interactable
{
    public Transform gameManager;
    public Canvas shopCanvas;
    List<Item> itemsInWeaponStore;
    AllShopsUI shopsUI;
    public CloseShopWhenMoveAway closeShop;

    private void Start()
    {
        itemsInWeaponStore = gameManager.GetComponent<WeaponStoreManager>().items;
        shopsUI = shopCanvas.GetComponentInChildren<AllShopsUI>();
    }

    public override void Interact()
    {
        shopsUI.UpdateUI(itemsInWeaponStore);
        shopsUI.inShop = true;
        shopCanvas.enabled = true;
        closeShop.SetShopTransform(this.transform);

    }
}
