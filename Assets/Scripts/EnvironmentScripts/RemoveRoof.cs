using UnityEngine;

public class RemoveRoof : MonoBehaviour
{
    //if player in distance then remove roof
    public float radius = 10f;
    Transform playerT;
    MeshRenderer[] roofToHide;
    MeshCollider[] colliders;
    BoxCollider[] boxColliders;
    public Transform parentTransformOfRoofs;
    private void Start()
    {
        playerT = PlayerTracker.instance.playerTransform;
        roofToHide = GetComponentsInChildren<MeshRenderer>();
        colliders = GetComponentsInChildren<MeshCollider>();
        boxColliders = GetComponentsInChildren<BoxCollider>();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

    private void Update()
    {
        float distance = Vector3.Distance(playerT.position, this.transform.position);
        if(distance <= radius)
        {

            for(int i = 0; i < roofToHide.Length; i++)
            {
                roofToHide[i].enabled = false;
                
            }
            for(int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
            for(int i = 0; i < boxColliders.Length; i++)
            {
                boxColliders[i].enabled = false;
            }
            
        } else
        {
            for (int i = 0; i < roofToHide.Length; i++)
            {
                roofToHide[i].enabled = true;
                
            }
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = true;
            }
            for (int i = 0; i < boxColliders.Length; i++)
            {
                boxColliders[i].enabled = true;
            }
        }
    }
}
