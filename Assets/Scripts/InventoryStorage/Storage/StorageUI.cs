using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageUI : MonoBehaviour
{
    YourStorage storage;
    public Transform parent;
    StorageSlot[] slots;
    StorageChest storageChest;
    private void Start()
    {
        storageChest = FindObjectOfType<StorageChest>();
        storage = YourStorage.instance;
        storage.onItemChangeCallback += UpdateUI;
        slots = parent.GetComponentsInChildren<StorageSlot>();
        UpdateUI();
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < storage.storage.Count)
            {
                slots[i].AddItem(storage.storage[i]);
            } else
            {
                slots[i].RemoveItem();
            }
        }
    }

    public void Close()
    {
        YourStorage.instance.isOpen = false;
        storageChest.storageCanvas.enabled = false;
        storageChest.inventoryCanvas.enabled = false;
    }
}
