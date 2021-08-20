using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    Equipment equipment;
    public Image image;
    EquipmentManager equipmentManager;
    private void Start()
    {
        equipmentManager = EquipmentManager.instance;
    }


    public void Add(Equipment equipment)
    {
        this.equipment = equipment;
        image.sprite = equipment.icon;
        image.enabled = true;
    }
    public void Remove()
    {
        
        equipment = null;
        image.enabled = false;
    }

    public void Unequipt()
    {
        if(equipment != null && !Inventory.instance.IsInventoryFull())
        {
            equipmentManager.onItemChangeCallback.Invoke(null, equipment);
            equipmentManager.UnEquipt(equipment);
            equipment = null;
            image.enabled = false;
        }
        
    }
}
