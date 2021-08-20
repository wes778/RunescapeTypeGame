using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    CharStats charStats;
    NavMeshAgent meshAgent;
    Animator animator;
    Animator playerAnimator;
    bool running;
    bool attacking;
    float timeBetweenAttacks;
    bool hasAppliedDamage;
    float animationTime;
    public bool isAlive;

    private void Start()
    {
        isAlive = true;
        target = PlayerTracker.instance.playerTransform;
        playerAnimator = target.GetComponentInChildren<Animator>();
        //print(playerAnimator.GetCurrentAnimatorStateInfo(0));
        charStats = GetComponent<CharStats>();
        charStats.OnDeath += Death;
        meshAgent = GetComponent<NavMeshAgent>();
        
        animator = GetComponent<Animator>();
    }

    void Death()
    {
        meshAgent.speed = 0f;
        meshAgent.angularSpeed = 0;
        meshAgent.acceleration = 0;
        animator.Play("Death");
        playerAnimator.Play("Locomotion");
        //playerAnimator.StartPlayback();
        isAlive = false;
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, this.transform.position);
        if(isAlive && distance <= lookRadius)
        { 
            meshAgent.SetDestination(target.position);
            if(!running && !attacking)
            {
                animator.Play("Running");
                running = true;
            }
            meshAgent.speed = 6f;
            meshAgent.angularSpeed = 350f;
            meshAgent.acceleration = 20f;
            meshAgent.updateRotation = false;

            FaceTarget();
            if (distance <= meshAgent.stoppingDistance && Time.time >= timeBetweenAttacks)
            {
                print("in distance");
                
                
                if (Time.time >= timeBetweenAttacks)
                {
                    attacking = true;
                    animator.Play("Attack");
                    animator.SetBool("isAttacking", true);
                    hasAppliedDamage = false;
                }

                //print(animationTime);
                timeBetweenAttacks = Time.time + animationTime;
                if(timeBetweenAttacks >= Time.time)
                {
                    attacking = false;
                }
                //attack target
                
            }


        }
    }
    public bool IsAlive()
    {
        return isAlive;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - this.transform.position).normalized;
        Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookDirection, Time.deltaTime * 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animationTime = animator.GetCurrentAnimatorStateInfo(0).length;
        }
        else
        {
            animationTime = 2f;
        }

        if (other.tag.CompareTo("Player") == 0 && !hasAppliedDamage)
        {
            IDamageable damageable = target.GetComponent<IDamageable>();
            if (damageable != null)
            {
                print("hit player");
                
                damageable.TakeHit(charStats.damage.GetValue());
                hasAppliedDamage = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {



        if (other.tag.CompareTo("Player") == 0 && !hasAppliedDamage)
        {
            IDamageable damageable = target.GetComponent<IDamageable>();
            if (damageable != null)
            {
                print("hit player");
                damageable.TakeHit(charStats.damage.GetValue());
                hasAppliedDamage = true;
            }
        }
    }
}
