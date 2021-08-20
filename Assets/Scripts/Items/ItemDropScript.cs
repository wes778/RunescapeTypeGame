using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropScript : MonoBehaviour
{
    public List<Item> itemsToDrop = new List<Item>();
    public float maxGoldDrop;
    public float minGoldDrop;
    CharStats enemyController;
    private void Start()
    {
        enemyController = GetComponent<CharStats>();
        enemyController.OnDeath += DropItems;
    }

    void DropItems()
    {
        for(int i = 0; i < itemsToDrop.Count; i++)
        {
            if(itemsToDrop[i].name.CompareTo("Gold") <= 0)
            {
                int goldToDrop = (int)Random.Range(minGoldDrop, maxGoldDrop);
                itemsToDrop[i].value = goldToDrop;
            }
            Instantiate(itemsToDrop[i].prefab, this.transform.position, this.transform.rotation);
        }
    }
}
