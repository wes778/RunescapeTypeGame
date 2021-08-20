using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = false;
    public bool hasInteracted = false;
    Transform player;
    public Transform interactionZone;

    

    private void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, this.transform.position);
            if (distance <= radius)
            {
                hasInteracted = true;
                Interact();
            }
        } 
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        hasInteracted = false;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
        PlayerTracker.instance.playerTransform.GetComponentInChildren<Animator>().Play("Locomotion");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

    public virtual void Interact()
    {
        
    }
}
