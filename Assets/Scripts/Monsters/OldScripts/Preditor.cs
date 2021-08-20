using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Preditor: LivingEntity
{
    public enum State { Idle, Chasing, Attacking };
    State currentState;
    Animator animator;
    Transform target;
    CharacterStats player;
    NavMeshAgent nav;
    AudioSource audioSource;
    public Item[] itemToDrop;
    float myCollisionRadius;
    float targetCollisionRadius;
    bool hasTarget;
    float timeBetweenAttacks;
    bool hasAppliedDamage;
    float animationTime;
    PlayerStats thisCharsStats;
    public float damage;

    public float minGoldDrop;
    public float maxGoldDrop;

    //WolfStats wolfStats;

    protected override void Start()
    {
        base.Start();
        //player setup
        target = FindObjectOfType<PlayerController>().transform;
        thisCharsStats = target.GetComponent<PlayerStats>();



        //thisCharsStats = GetComponent<CharacterStats>();
        audioSource = GetComponent<AudioSource>();
        hasAppliedDamage = false;
        animator = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        myCollisionRadius = GetComponent<CharacterController>().radius;
        targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;
        currentState = State.Idle;
        hasTarget = true;
        OnDeath += DeathAnimation;
        StartCoroutine(CheckInRange());


    }

 /*   protected void Start()
    {
        //base.Start();
        //player setup
        target = FindObjectOfType<PlayerController>().transform;
        player = target.GetComponent<CharacterStats>();

        wolfStats = GetComponent<WolfStats>();

        //thisCharsStats = GetComponent<CharacterStats>();
        audioSource = GetComponent<AudioSource>();
        hasAppliedDamage = false;
        animator = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        myCollisionRadius = GetComponent<CharacterController>().radius;
        targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;
        currentState = State.Idle;
        hasTarget = true;
        //OnDeath += DeathAnimation;
        StartCoroutine(CheckInRange());


    }*/


    #region testing something

    IEnumerator CheckInRange()
    {
        float refreshRate = 1f;
        animator.Play("Idle");
        while (hasTarget)
        {
            if (currentState == State.Idle)
            {


                if (Vector3.Distance(target.position, this.transform.position) <= 10f)
                {
                    currentState = State.Chasing;
                    StopCoroutine(CheckInRange());
                    animator.Play("Running");
                    audioSource.Play();

                    StartCoroutine(UpdatePath());
                    StartCoroutine(SmallerUpdate());
                }

            }
            yield return new WaitForSeconds(refreshRate);
        }
    }



    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;


        while (hasTarget)
        {
            //print(animator.GetFloat("Attack"));
            if (currentState == State.Chasing && target != null)
            {
                nav.stoppingDistance = 1f;
                nav.speed = 5f;
                nav.angularSpeed = 600f;
                nav.acceleration = 20f;
                /*Vector3 dirToTarget = (target.position - this.transform.position).normalized;
                Vector3 targetPosition = target.position - dirToTarget * ((myCollisionRadius + targetCollisionRadius) / 2);
                nav.SetDestination(targetPosition);*/
                //Vector3.Distance(this.transform.position, target.position) <= 2f
                nav.SetDestination(target.position);
                float distance = Vector3.Distance(target.position, this.transform.position);
                if (distance <= this.radius &&  Time.time >= timeBetweenAttacks)
                {

                    //this.transform.LookAt(target);
                    if (Time.time >= timeBetweenAttacks)
                    {

                        animator.Play("Attack");
                        animator.SetBool("isAttacking", true);
                        hasAppliedDamage = false;
                    }

                    //print(animationTime);
                    timeBetweenAttacks = Time.time + animationTime;





                }
                //animator.SetBool("isAttacking", false);


                //print(timeBetweenAttacks);
                //print(Time.time);
            }
            else
            {
                currentState = State.Idle;
                hasTarget = false;
                StopCoroutine(UpdatePath());
                StartCoroutine(CheckInRange());
            }
            yield return new WaitForSeconds(refreshRate);

        }




    }
    #endregion

    IEnumerator SmallerUpdate()
    {
        float refreshRate = .01f;

        while (hasTarget)
        {
            FaceTarget();
            yield return new WaitForSeconds(refreshRate);

        }
        
    }
    



    void DeathAnimation()
    {
        animator.Play("Death");
        animator.SetBool("isDead", true);
        currentState = State.Idle;
        this.enabled = false;
        hasTarget = false;
        if (itemToDrop != null)
        {
            for (int i = 0; i < itemToDrop.Length; i++)
            {
                if (itemToDrop != null)
                {
                    if(itemToDrop[i].name.Equals("Gold"))
                    {
                        //SetGoldToDrop(itemToDrop[i], minGoldDrop, maxGoldDrop); 
                    }
                    Instantiate(itemToDrop[i].prefab, this.transform.position, this.transform.rotation);
                }

            }

        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - this.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * 5f);
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
            IDamageable damageable = thisCharsStats.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeHit(damage);
                hasAppliedDamage = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {


        if (other.tag.CompareTo("Player") == 0 && !hasAppliedDamage)
        {
            IDamageable damageable = thisCharsStats.GetComponent<IDamageable>();
            if (damageable != null)
            {
                
                damageable.TakeHit(damage);
                hasAppliedDamage = true;
            }
        }
    }


}
