using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftableSlot : MonoBehaviour
{
    CraftableItem craftableItem;
    public Image image;
    public void Add(CraftableItem craftableItem)
    {
        this.craftableItem = craftableItem;
        image.sprite = craftableItem.itemToCraft.icon;
        image.enabled = true;
    }
    public void Remove()
    {
        this.craftableItem = null;
        image.enabled = false;
    }
    public void Craft()
    {
        craftableItem.Craft();
    }
}
