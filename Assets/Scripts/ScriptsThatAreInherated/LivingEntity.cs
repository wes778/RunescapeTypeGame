using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class LivingEntity : Interactable, IDamageable
{
    public float startingHealth;
    float currentHealth;
    public bool isDead;
    public event System.Action OnDeath;
    public delegate void OnTakeHit();
    public OnTakeHit onTakeHitCallBack;

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    protected virtual void Start()
    {
        currentHealth = startingHealth;
        //print("this is current health " + currentHealth);
    }

    public virtual void TakeHit(float damage)
    {
        
        PlayerStats playerStats = GetComponent<PlayerStats>();
        if(playerStats != null)
        {
            int currentArmor = playerStats.armor.GetValue();
            int hitAmount = (int)damage - currentArmor;
            if(hitAmount < 0)
            {
                hitAmount = 0;
            }
            currentHealth -= hitAmount;
        } else
        {
            currentHealth -= damage;
        }
        print(currentHealth + " this is current health");
        print("took damage" + damage);
        if (onTakeHitCallBack != null)
        {
            onTakeHitCallBack.Invoke();
        }
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(Consumable healthPotion)
    {
        if(currentHealth == startingHealth)
        {
            return;
        }
        currentHealth += healthPotion.healAmount;
        Inventory.instance.Remove(healthPotion);
        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }
        if (onTakeHitCallBack != null)
        {
            onTakeHitCallBack.Invoke();
        }


    }

    public virtual void Die()
    {
        isDead = true;
        if(OnDeath != null)
        {
            OnDeath();
        }
        //this needs to change but for now its a temp fix
        PlayerTracker.instance.playerTransform.GetComponentInChildren<Animator>().Play("Locomotion");
        GameObject.Destroy(gameObject,2f);

    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }


}
