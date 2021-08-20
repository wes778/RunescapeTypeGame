using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtToBeTilled : Interactable
{
    Equipment currentEquipment;
    public TilledDirt tilledDirt;
    Animator animator;
    int hitCount;
    MeshRenderer meshRenderer;
    private void Start()
    {
        animator = PlayerTracker.instance.playerTransform.GetComponentInChildren<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public override void Interact()
    {
        currentEquipment = EquipmentManager.instance.GetEquipmentInSlot(4);
        meshRenderer = GetComponent<MeshRenderer>();
        if(currentEquipment != null)
        {
            if (currentEquipment.name.Equals("Hoe") && meshRenderer.enabled == true)
            {
                animator.Play("Tilling");
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(currentEquipment != null)
        {
            if (currentEquipment.name.Equals("Hoe") && animator.GetCurrentAnimatorStateInfo(0).IsName("Tilling"))
            {
                hitCount++;
                if (hitCount >= 3)
                {
                    Instantiate(tilledDirt, this.transform.position, this.transform.rotation);
                    Destroy(this.gameObject);
                    animator.Play("Locomotion");
                }
            }
        }
        
    }
}
