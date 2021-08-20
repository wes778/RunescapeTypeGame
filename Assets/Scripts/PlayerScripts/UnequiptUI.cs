using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnequiptUI : MonoBehaviour
{
    public Transform parentTransform;
    EquipmentManager equipmentManager;
    EquipmentSlot[] equipmentSlots;
    PlayerStats playerStats;
    Text[] texts;
    private void Start()
    {
        equipmentManager = EquipmentManager.instance;
        equipmentSlots = GetComponentsInChildren<EquipmentSlot>();
        equipmentManager.onUpdatingUICallback += UpdateUI;
        playerStats = PlayerTracker.instance.GetComponent<PlayerStats>();
        texts = GetComponentsInChildren<Text>();
    }

    public void UpdateUI()
    {
        for(int i = 0; i < equipmentSlots.Length; i++ )
        {
            if(equipmentManager.currentEquipment[i] != null)
            {
                // equipmentSlots
                equipmentSlots[i].Add(equipmentManager.currentEquipment[i]);
            }
            else
            {
                equipmentSlots[i].Remove();
            }
        }

        texts[0].text = "Attack: " + playerStats.damage.GetValue();
        texts[1].text = "Armor: " + playerStats.armor.GetValue();
    }
}
