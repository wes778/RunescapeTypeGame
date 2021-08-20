using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusStat
{
    public int BonusValue { get; set; }

    public BonusStat(int bonusStat)
    {
        this.BonusValue = bonusStat;
        Debug.Log("Bonus stat added");
    }
}
