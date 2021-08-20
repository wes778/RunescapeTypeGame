using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStore : Interactable
{

    public Transform gameManager;
    public Canvas shopCanvas;
    List<Item> itemsInGeneralStore;
    AllShopsUI shopsUI;
    public CloseShopWhenMoveAway closeShop;

    private void Start()
    {
        itemsInGeneralStore = gameManager.GetComponent<GeneralStoreManager>().items;
        shopsUI = shopCanvas.GetComponentInChildren<AllShopsUI>();
    }

    public override void Interact()
    {
        shopsUI.UpdateUI(itemsInGeneralStore);
        shopsUI.inShop = true;
        shopCanvas.enabled = true;
        closeShop.SetShopTransform(this.transform);

    }

    /*
        public void AddItem(Item itemToAdd)
        {
            shopItems.Add(itemToAdd);
        }
        public void RemoveItem(Item itemToRemove)
        {
            shopItems.Remove(itemToRemove);
        }*/
}
