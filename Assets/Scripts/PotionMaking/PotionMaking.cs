using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMaking : Interactable
{
   
    Canvas canvasToShow;
    Transform gameManager;
    List<CraftableItem> craftableItems;

    private void Start()
    {
        canvasToShow = GameObject.FindGameObjectWithTag("CraftingCanvas").GetComponent<Canvas>();
        gameManager = DialogueManager.Instance.GetComponent<Transform>();
        craftableItems = gameManager.GetComponent<PotionMakingManager>().listOfItemsToCraft;
    }
    public override void Interact()
    {
        MeshRenderer mesh = GetComponentInChildren<MeshRenderer>();
        if(mesh.enabled)
        {
            canvasToShow.GetComponentInChildren<CraftingUI>().UpdateUI(craftableItems);
            canvasToShow.enabled = true;
        }
        
    }
}
