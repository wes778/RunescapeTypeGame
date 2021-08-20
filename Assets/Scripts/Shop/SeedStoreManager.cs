using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedStoreManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void AddSeed(Item item)
    {
        items.Add(item);
    }
}
