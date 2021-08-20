using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouching : MonoBehaviour
{
    int radius = 1;
    // Update is called once per frame
    Color startingColor;
    PlayerController playerController;
    string currentColliderTag;
    Renderer[] renderers;
    public Material blueMaterial;
    public Material redMaterial;
    //ChangeColor changeColor;

    private void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        ChangeBlue();
        //changeColor = new ChangeColor();
        //startingColor = this.gameObject.GetComponent<Renderer>().material.color;
        playerController = PlayerTracker.instance.GetComponent<PlayerController>();
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radius);
        playerController.SetAllowedToBuild(true);
        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].tag.Equals("NotBuildable"))
            {
                playerController.SetAllowedToBuild(false);
                ChangeRed();
            }
        }
    }

    void ChangeBlue()
    {
        for(int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = blueMaterial;
        }
    }

    void ChangeRed()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = redMaterial;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(other.tag);
        if(!other.gameObject.tag.Equals("Buildable") && other.gameObject.tag.Length >= 1)
        {
            print("Should change red");
            currentColliderTag = other.gameObject.tag;
            playerController.SetAllowedToBuild(false);
            ChangeRed();
            //this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag.Equals(currentColliderTag))
        {
            playerController.SetAllowedToBuild(true);
            currentColliderTag = null;
            ChangeBlue();
            //this.gameObject.GetComponent<Renderer>().material.color = startingColor;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals(currentColliderTag))
        {
            ChangeRed();
            //this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
