using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableManager : MonoBehaviour
{
    PlayerStats playerLivingEntity; //this has living entity in it
    private void Start()
    {
        playerLivingEntity = PlayerTracker.instance.GetComponent<PlayerStats>();
    }
    #region
    public static ConsumableManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one instance of Consumable Manager");
            return;
        }
        instance = this;
    }
    #endregion

    public void Heal(Consumable consumable)
    {
        playerLivingEntity.Heal(consumable);
        //get the players living entity and use heal method
    }
}
