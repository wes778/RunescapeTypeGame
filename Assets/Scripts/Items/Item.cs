using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "Item name";
    public GameObject prefab = null;
    
    public Sprite icon = null;
    public int sellValue;
    public int value;

    public virtual void Use()
    {
        //Debug.Log("Used item " + name);

    }

    public void MoveItemToStorage()
    {
        YourStorage.instance.Add(this);
    }

    public void SellItem()
    {
        
        Inventory.instance.gold += this.sellValue;
        //Shop.instance.AddItem(this);
        Inventory.instance.Remove(this);
/*        if (Shop.instance.onItemChangeCallBack != null)
        {
            Shop.instance.onItemChangeCallBack.Invoke();
        }*/
        if(Inventory.instance.onItemChangedCallBack != null)
        {
            Inventory.instance.onItemChangedCallBack.Invoke();
        }
    }



}
