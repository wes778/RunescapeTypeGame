using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsShopManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public void AddTool(Item item)
    {
        items.Add(item);
    }
}
