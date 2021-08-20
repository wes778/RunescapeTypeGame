
using UnityEngine;
using UnityEngine.AI;

public class InteractableOld : MonoBehaviour
{
    NavMeshAgent playerAgent;
    bool hasInteracted;
    float stoppingDistance;
    //Transform target;
    const float stoppingDistanceThreshhold = .5f;
    LivingEntity livingEntity;
    public virtual void MoveToInteract(NavMeshAgent playerAgent)
    {
        //this.target = target;
        livingEntity = GetComponent<LivingEntity>();
        if (livingEntity != null)
        {
            stoppingDistance = this.transform.GetComponent<NavMeshAgent>().radius + stoppingDistanceThreshhold;
        } else
        {
            stoppingDistance = this.transform.GetComponent<CapsuleCollider>().radius + 2f;
        }
        hasInteracted = false;
        this.playerAgent = playerAgent;
        this.playerAgent.SetDestination(this.transform.position);
        this.playerAgent.stoppingDistance = stoppingDistance;
        //print(stoppingDistance);

        //Interact();
    }

/*    void FaceTarget()
    {
        Vector3 direction = (target.position - playerAgent.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(playerAgent.transform.rotation, lookRotation, Time.deltaTime * 5f);
    }*/

    private void Update()
    {
/*        if(target != null)
        {
            float distance = Vector3.Distance(target.position, playerAgent.transform.position);
            if (distance <= playerAgent.stoppingDistance)
            {
                FaceTarget();
            }
        }*/
        
        if (playerAgent != null && !playerAgent.pathPending)
        {
            if (!hasInteracted && playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                //print("Interacted");
                Interact();
                hasInteracted = true;
            }
        }
        
       
    }
    public virtual void Interact()
    {
        livingEntity = GetComponent<LivingEntity>();
        if(livingEntity != null)
        {
            //this needs to change!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            
           // Transform playerTransform = PlayerWeaponController.instance.GetComponent<Transform>();
           // Animator animator = PlayerWeaponController.instance.GetComponentInChildren<Animator>();
           // playerTransform.LookAt(this.transform);
            //PlayerWeaponController.instance.Attack(animator);
            //PlayerWeaponController.instance.Attack(animator);
            
        }
        //print("This is the base class");
    }
}
