using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public int damage = 0;
    public int armor = 0;
    public EquiptSlot slotToEquipt;

    public override void Use()
    {
        
        
        
         EquipmentManager.instance.Equipt(this);
        
        

    }
}

public enum EquiptSlot { Head, Chest, Legs, Feet, Sword, Shield}
