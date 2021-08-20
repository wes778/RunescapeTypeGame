using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharStats
{
    protected override void Start()
    {
        base.Start();
        EquipmentManager.instance.onItemChangeCallback += OnEquipmentChanged;
    }
    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            armor.AddModifier(newItem.armor);
            damage.AddModifier(newItem.damage);
            
        }

        if(oldItem != null)
        {
            armor.RemoveModifier(oldItem.armor);
            damage.RemoveModifier(oldItem.damage);
        }

        print(damage.GetValue());
        print(armor.GetValue());

    }
}
