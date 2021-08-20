using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseShopWhenMoveAway : MonoBehaviour
{
    Transform playerTransform;
    Transform shopTransform;
    AllShopsUI shopsUI;
    void Start()
    {
        shopsUI = GetComponentInChildren<AllShopsUI>();
        playerTransform = PlayerTracker.instance.playerTransform;
    }

    // Update is called once per frame
    void Update()
    {
        if(shopTransform != null)
        {
            float distance = Vector3.Distance(playerTransform.position, shopTransform.position);
            if(distance >= 5f)
            {
                shopsUI.Close();
                ResetTransform();
            }
            //then its looking at respective shop
        }
    }
    public void SetShopTransform(Transform transform)
    {
        shopTransform = transform;
    }
    public void ResetTransform()
    {
        shopTransform = null;
    }
}
