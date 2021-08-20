
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    Item item;
    public Image ShopSlotImage;
    Inventory inventory;
    //Shop shop;


    private void Start()
    {
        inventory = Inventory.instance;
        //shop = GameObject.FindGameObjectWithTag
        
    }
    public void AddItem(Item itemToAdd)
    {
        //print(itemToAdd.name);
        item = itemToAdd;
        ShopSlotImage.sprite = itemToAdd.icon;
        ShopSlotImage.enabled = true;

    }
    public void RemoveItem()
    {
        item = null;
        ShopSlotImage.sprite = null;
        ShopSlotImage.enabled = false;
    }
    public void Buy()
    {
        //print("trying to buy " + item.name);
        if (item != null)
        {
            if (inventory.gold >= item.value)
            {
                inventory.Add(item);
                inventory.gold -= item.value;
                //Shop.instance.RemoveItem(item);

/*                if (Shop.instance.onItemChangeCallBack != null)
                {
                    Shop.instance.onItemChangeCallBack.Invoke();
                }*/
                if (Inventory.instance.onItemChangedCallBack != null)
                {
                    Inventory.instance.onItemChangedCallBack.Invoke();
                }
            }
        }

    }
}
