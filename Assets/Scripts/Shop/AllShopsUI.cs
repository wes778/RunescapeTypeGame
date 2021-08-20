using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllShopsUI : MonoBehaviour
{
    public Transform slotParents;
    ShopSlot[] shopSlots;
    Canvas canvasToClose;
    public bool inShop;



    private void Start()
    {

        shopSlots = slotParents.GetComponentsInChildren<ShopSlot>();
        canvasToClose = GetComponentInParent<Canvas>();
        inShop = false;

    }


    public void UpdateUI(List<Item> itemsInShop)
    {
        for (int i = 0; i < shopSlots.Length; i++)
        {
            if (i < itemsInShop.Count)
            {
                shopSlots[i].AddItem(itemsInShop[i]);
            }
            else
            {
                shopSlots[i].RemoveItem();
            }
        }
    }

    public void Close()
    {
        canvasToClose.enabled = false;
        inShop = false;
    }
}
