using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCrop : MonoBehaviour
{
    //public int growTime;
    Seed currentCropSeed;
    Transform dirtPile;
    void Start()
    {
        StartCoroutine(Grow());
    }

    public void SetSeed(Seed seed)
    {
        currentCropSeed = seed;
    }

    public void SetDirtMound(Transform dirtPile)
    {
        this.dirtPile = dirtPile;
    }

    IEnumerator Grow()
    {
        yield return new WaitForSeconds(currentCropSeed.timeToGrow);
        
        Destroy(this.gameObject);

        FinalCrop fc = Instantiate(currentCropSeed.finalCrop, dirtPile.position, dirtPile.rotation);
        fc.transform.SetParent(dirtPile);
        fc.SetCurrentCropSeed(currentCropSeed);
        
    }
}
