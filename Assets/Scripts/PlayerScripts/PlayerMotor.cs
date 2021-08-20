using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void Move(Vector3 postitionToMove)
    {
        agent.SetDestination(postitionToMove);
    }

    public void FollowTarget(Interactable interactable)
    {
        agent.stoppingDistance = interactable.radius * .7f;
        agent.updateRotation = false;
        if(interactable.interactionZone == null)
        {
            target = interactable.transform;
        }
        else
        {
            target = interactable.interactionZone;
        }
        
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - this.transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * 5f);

    }
}
