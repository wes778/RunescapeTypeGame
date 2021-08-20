using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    //in game manager
    public List<Item> shopItems = new List<Item>();
    public bool inShop;
    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallBack;
    #region Singleton
    public static Shop instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of shop");
            return;
        }
        instance = this;
    }
    #endregion 

    public void AddItem(Item itemToAdd)
    {
        shopItems.Add(itemToAdd);
    }
    public void RemoveItem(Item itemToRemove)
    {
        shopItems.Remove(itemToRemove);
    }
}
