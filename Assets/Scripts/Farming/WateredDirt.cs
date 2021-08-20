using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateredDirt : MonoBehaviour
{
    Seed currentSeed;
    Transform[] dirtPiles;
    int cropCount;
    private void Start()
    {
        dirtPiles = GetComponentsInChildren<Transform>();
    }
    public Seed GetCurrentSeed()
    {
        return currentSeed;
    }

    public void SetSeed(Seed seedToSet)
    {
        currentSeed = seedToSet;
        PlantSeed();
    }

    public void DecreaseCropCount()
    {
        cropCount--;
    }

    public int GetCurrentCropCount()
    {
        return cropCount;
    }

    void PlantSeed()
    {
        for(int i = 1; i < dirtPiles.Length; i++)
        {
            StartingCrop sc = Instantiate(currentSeed.startingCrop, dirtPiles[i].transform.position, dirtPiles[i].transform.rotation);
            sc.gameObject.transform.SetParent(dirtPiles[i].transform);
            sc.SetDirtPiles(dirtPiles[i]);
            sc.SetCurrentSeed(currentSeed);
            cropCount++;
        }
        
        
    }
}
