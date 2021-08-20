using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NonPreditor : LivingEntity
{
    #region dont delete this code
    /* public enum State { Idle, Chasing, Attacking };
     State currentState;
     Animator animator;
     Transform target;
     CharacterStats player;
     NavMeshAgent nav;
     AudioSource audioSource;
     float myCollisionRadius;
     float targetCollisionRadius;
     bool hasTarget;
     float timeBetweenAttacks;
     public float damage;
     bool hasAppliedDamage;
     float animationTime;
     protected override void Start()
     {
         base.Start();
         audioSource = GetComponent<AudioSource>();
         target = FindObjectOfType<CharacterStats>().transform;
         hasAppliedDamage = false;
         player = FindObjectOfType<CharacterStats>();
         animator = GetComponent<Animator>();
         nav = GetComponent<NavMeshAgent>();
         myCollisionRadius = GetComponent<CharacterController>().radius;
         targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;
         currentState = State.Idle;
         hasTarget = false;





     }



     private void Update()
     {
         //print(hasTarget);
         if(getCurrentHealth() < startingHealth)
         {
             if(!hasTarget)
             {
                 hasTarget = true;
                 //print("testing");
                 currentState = State.Chasing;
                 StartCoroutine(UpdatePath());
             }

         }


     }

     IEnumerator UpdatePath()
     {
         float refreshRate = .25f;


         while (hasTarget)
         {
             //print("test");
             if (currentState == State.Chasing && target != null)
             {
                 nav.speed = 3f;
                 nav.acceleration = 2.5f;
                 Vector3 dirToTarget = (target.position - this.transform.position).normalized;
                 Vector3 targetPosition = target.position - dirToTarget * ((myCollisionRadius + targetCollisionRadius) / 2);
                 nav.SetDestination(targetPosition);
                 if (Vector3.Distance(this.transform.position, target.position) <= 2f && Time.time >= timeBetweenAttacks)
                 {


                     if (Time.time >= timeBetweenAttacks)
                     {
                         this.transform.LookAt(target);
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

             }
             yield return new WaitForSeconds(refreshRate);

         }




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
             IDamageable damageable = player.GetComponent<IDamageable>();
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
             IDamageable damageable = player.GetComponent<IDamageable>();
             if (damageable != null)
             {
                 damageable.TakeHit(damage);
                 hasAppliedDamage = true;
             }
         }
     }*/
    #endregion

    public enum State { Idle, Chasing, Attacking };
    State currentState;
    Animator animator;
    Transform target;
    CharacterStats player;
    NavMeshAgent nav;
    AudioSource audioSource;
    float myCollisionRadius;
    float targetCollisionRadius;
    bool hasTarget;
    float timeBetweenAttacks;
    public float damage;
    bool hasAppliedDamage;
    float animationTime;
    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
        target = FindObjectOfType<CharacterStats>().transform;
        hasAppliedDamage = false;
        player = FindObjectOfType<CharacterStats>();
        animator = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        myCollisionRadius = GetComponent<CharacterController>().radius;
        targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;
        currentState = State.Idle;
        hasTarget = true;
        OnDeath += DeathAnimation;
        animator.Play("Idle");
        StartCoroutine(CheckIfHurt());

    }



    IEnumerator CheckIfHurt()
    {
        float refreshRate = .1f;



        while (!hasTarget)

            if (getCurrentHealth() < startingHealth)
            {
                if (!hasTarget)
                {
                    hasTarget = true;
                    //print("testing");
                    currentState = State.Chasing;
                    StartCoroutine(UpdatePath());
                }

            }
        yield return new WaitForSeconds(refreshRate);
    }


    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;


        while (hasTarget)
        {
            //print(animator.GetFloat("Attack"));
            if (currentState == State.Chasing && target != null)
            {
                nav.speed = 5f;
                nav.angularSpeed = 600f;
                nav.acceleration = 20f;
                Vector3 dirToTarget = (target.position - this.transform.position).normalized;
                Vector3 targetPosition = target.position - dirToTarget * ((myCollisionRadius + targetCollisionRadius) / 2);
                nav.SetDestination(targetPosition);
                if (Vector3.Distance(this.transform.position, target.position) <= 2f && Time.time >= timeBetweenAttacks)
                {

                    this.transform.LookAt(target);
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
            }
            yield return new WaitForSeconds(refreshRate);

        }




    }

    void DeathAnimation()
    {
        animator.Play("Death");
        animator.SetBool("isDead", true);
        currentState = State.Idle;
        hasTarget = false;

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
            IDamageable damageable = player.GetComponent<IDamageable>();
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
            IDamageable damageable = player.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeHit(damage);
                hasAppliedDamage = true;
            }
        }
    }

}
