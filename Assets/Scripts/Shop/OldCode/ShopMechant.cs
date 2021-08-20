using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMechant : Interactable
{
    public Canvas shopCanvas;
    public Canvas inventoryCanvas;
    public override void Interact()
    {
        if(Shop.instance.onItemChangeCallBack != null)
        {
            Shop.instance.onItemChangeCallBack.Invoke();
        }
        Shop.instance.inShop = true;
        shopCanvas.enabled = true;
        inventoryCanvas.enabled = true;
    }

}
