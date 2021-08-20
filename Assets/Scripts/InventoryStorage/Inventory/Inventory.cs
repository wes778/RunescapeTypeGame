using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    public int gold;
    
    public int maxInventorySize = 20;
    public Image image;
    int numItemsInInventory;




    public List<Item> items = new List<Item>();

    private void Start()
    {
        numItemsInInventory = items.Count;
    }
    public bool Add(Item item)
    {
        //PlayerWeaponController.instance.equipWeapon(item);
        if(items.Count >= maxInventorySize)
        {
            return false;
        }
        items.Add(item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
            if(YourStorage.instance.onItemChangeCallback != null)
            {
                //YourStorage.instance.Remove(item);
                YourStorage.instance.onItemChangeCallback.Invoke();
            }
        }
        numItemsInInventory++;
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
        numItemsInInventory--;
    }

    public bool HasItem(Item itemToCheckFor)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i].Equals(itemToCheckFor))
            {
                return true;
            }
        }
        return false;
    }

    public int Count(Item item)
    {
        int returnCount = 0;
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i].Equals(item))
            {
                returnCount++;
            }
        }
        return returnCount;
    }

    public bool IsInventoryFull()
    {
        print(numItemsInInventory);
        return numItemsInInventory == 20; 
    }

    public bool HasAllItems(Item[] itemsNeeded)
    {
        List<Item> itemsYouHave = new List<Item>();
        //List<int> placeFound = new List<int>();

        for (int i = 0; i < itemsNeeded.Length; i++)
        {
            if (HasItem(itemsNeeded[i]))
            {
                itemsYouHave.Add(itemsNeeded[i]);
                Remove(itemsNeeded[i]);
            }
        }

        if (itemsNeeded.Length == itemsYouHave.Count)
        {
            return true;
        }
        else
        {
            for (int i = 0; i < itemsYouHave.Count; i++)
            {
                Add(itemsYouHave[i]);
            }
            return false;
        }
    }


}
