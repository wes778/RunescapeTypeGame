using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBuilding : MonoBehaviour
{
    public MeshRenderer[] meshRenderers;
    RemoveRoof removeRoof;
    int buildCount;
    bool houseBuilt;
    private void Awake()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        removeRoof = GetComponentInChildren<RemoveRoof>();
        houseBuilt = false;
        for(int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].enabled = false;
        }
    }

    public void Build()
    {
        if (buildCount < meshRenderers.Length)
        {
            meshRenderers[buildCount].enabled = true;
            buildCount++;
        } 
        else
        {
            houseBuilt = true;
            removeRoof.enabled = true;
        }
        
    }

    public bool GetHouseBuiltStatus()
    {
        return houseBuilt;
    }
}
