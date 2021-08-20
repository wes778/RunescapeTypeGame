using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    PlayerStats playerStats;
    float timeToDealDamage;
    bool hasAppliedDamage;
    Animator animator;


    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        animator = playerStats.GetComponentInChildren<Animator>();

        
    }
    public void Attack()
    {
        
        if (Time.time >= timeToDealDamage)
        {
            hasAppliedDamage = false;
            timeToDealDamage = Time.time + 1f;

        }
    }




    private void OnTriggerEnter(Collider other)
    {
        Attack();
        //print(Time.time + " this is Time.time");
        //print(timeToDealDamage + " this is time to deal damage");

        if (!hasAppliedDamage && Time.time <= timeToDealDamage && animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                hasAppliedDamage = true;
                print(playerStats.damage.GetValue());
                damageable.TakeHit(playerStats.damage.GetValue());
            }

        }

    }

}

    


