using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public Transform slotParents;
    ShopSlot[] shopSlots;
    public Shop shop;
    ShopMechant shopMechant;


    private void Start()
    {
        shopMechant = FindObjectOfType<ShopMechant>();
        shopSlots = slotParents.GetComponentsInChildren<ShopSlot>();
        shop = Shop.instance;
        shop.onItemChangeCallBack += UpdateUI;
        //UpdateUI();
        
    }
    void UpdateUI()
    {
        for(int i = 0; i < shopSlots.Length; i++)
        {
            if(i < shop.shopItems.Count)
            {
                shopSlots[i].AddItem(shop.shopItems[i]);
            } else
            {
                shopSlots[i].RemoveItem();
            }
        }
    }

    public void Close()
    {

        shopMechant.shopCanvas.enabled = false;
        shopMechant.inventoryCanvas.enabled = false;
        shop.inShop = false;
    }
}
