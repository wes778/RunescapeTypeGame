using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Button removeButton;
    Item item;
    public AllShopsUI allShopsUI;
    private void Start()
    {
        allShopsUI = GetComponentInParent<ToFind>().GetComponentInChildren<AllShopsUI>();
    }

    public void AddItem(Item item)
    {
        this.item = item;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void RemoveItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Transform c = PlayerTracker.instance.playerTransform;
        if(item != null)
        {
            Instantiate(item.prefab, c.transform.position, c.transform.rotation);
            Inventory.instance.Remove(item);
        }
        
        
        
    }

    public void UseItem()
    {

        //if storage bool open is true move to storage
        //item.MoveItemToStorage();
        //else 
        if (YourStorage.instance.isOpen)
        {
            item.MoveItemToStorage();
        }
        else if (allShopsUI.inShop)
        {
            item.SellItem();
        }
        else
        {
            if (item != null)
            {
                item.Use();
            }

        }

        /*else if (allShopsUI.inShop)
        {
            item.SellItem();
        }*/

    }
}
