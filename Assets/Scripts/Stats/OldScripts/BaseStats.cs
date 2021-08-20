using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats
{
    public int BaseValue { get; set; }
    public string ValueType { get; set; }

    public string ValueInfo { get; set; }

    private int totalValue;
    public List<BonusStat> BonusValues { get; set; }


    public BaseStats(int baseValue, string valueType, string valueInfo)
    {
        this.BonusValues = new List<BonusStat>();
        this.BaseValue = baseValue;
        this.ValueType = valueType;
        this.ValueInfo = valueInfo;
    }

    public void AddBonusValue(int valueToAdd)
    {
        BonusValues.Add(new BonusStat(valueToAdd));
    }

    public void RemoveBonusValue(int valueToRemove)
    {
        BonusStat temp = null;
        for(int i = 0; i < BonusValues.Count; i++)
        {
            if(valueToRemove == BonusValues[i].BonusValue)
            {
                temp = BonusValues[i];
                break;
            }
        }
        if(temp != null)
        {
            BonusValues.Remove(temp);
        }
    }

    public int GetTotalValue()
    {
        totalValue = BaseValue;
        BonusValues.ForEach(x => totalValue += x.BonusValue);
        return totalValue;
    }

}
