using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
/*

    // CharacterStats charStats;
    public static PlayerWeaponController instance;
    MeleeWeapon meleeWeapon;
    #region Singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance");
            return;
        }
        instance = this;
    }
    #endregion
    private void Start()
    {
        meleeWeapon = FindObjectOfType<MeleeWeapon>();
    }*/


    #region old code
    /*    public Transform playerHold;
     CharacterStats charStats;
     MeleeWeapon equippedWeapon;
     public MeleeWeapon startingWeapon;
     private void Start()
     {
         charStats = GetComponent<CharacterStats>();
         equipWeapon(startingWeapon);
     } 

     public void equipWeapon(MeleeWeapon weaponToEquip)
     {
         if (equippedWeapon != null)
         {
             Destroy(equippedWeapon.gameObject);

             charStats.RemoveBonusStat(equippedWeapon.GetItem().thisDamage, "Damage");
         }
         //charStats.GetTotalValue("Damage");
         equippedWeapon = Instantiate(weaponToEquip, playerHold.position, playerHold.rotation);
         equippedWeapon.transform.SetParent(playerHold);
         charStats.AddBounusValue(equippedWeapon.GetItem().thisDamage, "Damage");
         ItemPickup itemPickup = weaponToEquip.GetComponent<ItemPickup>();
         if (itemPickup != null)
         {
             itemPickup.enabled = false;
         }
         print(charStats.GetTotalValue("Damage"));

     }

     public void Attack()
     {
         equippedWeapon.Attack();
     }


     public MeleeWeapon GetCurrentWeapon()
     {
         return equippedWeapon;
     }*/
    #endregion
}
