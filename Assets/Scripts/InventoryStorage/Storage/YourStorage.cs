using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourStorage : MonoBehaviour
{
    public List<Item> storage = new List<Item>();
    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;
    public int maxItems;


    public bool isOpen = false;
    public static YourStorage instance;

    #region Singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of storage");
            return;
        }
        instance = this;
    }
    #endregion

    public void Add(Item newItem)
    {
        if (storage.Count < maxItems)
        {
            storage.Add(newItem);
            Inventory.instance.Remove(newItem);

            if (onItemChangeCallback != null)
            {
                //print("onItemChangeCallback not null");
                onItemChangeCallback.Invoke();
                if (Inventory.instance.onItemChangedCallBack != null)
                {
                    Inventory.instance.onItemChangedCallBack.Invoke();
                }
            }


        }
    }

    public void Remove(Item itemToRemove)
    {
        storage.Remove(itemToRemove);
        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
    }

}
