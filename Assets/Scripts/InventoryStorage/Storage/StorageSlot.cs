using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageSlot : MonoBehaviour
{
    Item item;
    public Image icon;

    public void AddItem(Item itemToAdd)
    {
        this.item = itemToAdd;
        icon.sprite = itemToAdd.icon;
        icon.enabled = true;

        
    }
    public void RemoveItem()
    {
        this.item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void MoveToInventory()
    {
        if(item != null)
        {
            Inventory.instance.Add(item);
            YourStorage.instance.Remove(item);
            RemoveItem();

            if (Inventory.instance.onItemChangedCallBack != null)
            {
                Inventory.instance.onItemChangedCallBack.Invoke();
            }
            if (YourStorage.instance.onItemChangeCallback != null)
            {
                YourStorage.instance.onItemChangeCallback.Invoke();
            }
        }
        
    }
}
