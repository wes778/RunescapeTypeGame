using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCrop : MonoBehaviour
{
    //public int growTime;
    Transform dirtPile;
    Seed currentCropSeed;
    void Start()
    {
        StartCoroutine(Grow());
    }
    public void SetDirtPiles(Transform dirtPile)
    {
        this.dirtPile = dirtPile;
    }
    public void SetCurrentSeed(Seed seed)
    {
        currentCropSeed = seed;
    }

    IEnumerator Grow()
    {
        yield return new WaitForSeconds(currentCropSeed.timeToGrow);
        //Transform dirtMoundTransform = GetComponentInParent<Transform>();
        //Seed currentCropSeed = GetComponentInParent<WateredDirt>().GetCurrentSeed();
        Destroy(this.gameObject);
        
        MiddleCrop mc = Instantiate(currentCropSeed.middleCrop, dirtPile.position, dirtPile.rotation);
        mc.gameObject.transform.SetParent(dirtPile.transform);
        mc.SetSeed(currentCropSeed);
        mc.SetDirtMound(dirtPile);
    }

}
