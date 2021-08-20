using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpdate : MonoBehaviour
{
    Text healthText;
    PlayerStats playerTransform;
    private void Start()
    {
        healthText = GetComponent<Text>();
        playerTransform = PlayerTracker.instance.transform.GetComponent<PlayerStats>();
        //print(playerTransform.getCurrentHealth().ToString());
        healthText.text = playerTransform.getCurrentHealth().ToString();
        playerTransform.onTakeHitCallBack += UpdateHealth;
    }

    void UpdateHealth()
    {
        healthText.text = playerTransform.getCurrentHealth().ToString();
    }

}
