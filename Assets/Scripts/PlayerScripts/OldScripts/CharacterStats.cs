using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : LivingEntity
{
    public List<BaseStats> baseStats = new List<BaseStats>();

    public int Damage;
    public int Armor;
    protected override void Start()
    {
        base.Start();
        baseStats.Add(new BaseStats(Damage, "Damage", "How much damage you do"));
        baseStats.Add(new BaseStats(Armor, "Armor", "How much armor you have"));
    }

    private BaseStats FindBaseStat(string str)
    {
        BaseStats baseStat = null;
        baseStat = baseStats.Find(x => x.ValueType.CompareTo(str) == 0);
        return baseStat;
    }

    public void AddBounusValue(int valueToAdd, string str)
    {
        BaseStats baseStat = FindBaseStat(str);
        if(baseStat != null)
        {
            baseStat.AddBonusValue(valueToAdd);
        }
    }

    public float GetTotalValue(string str)
    {
        BaseStats getTotalValue = FindBaseStat(str);
        
        return getTotalValue.GetTotalValue();
        
        
    }

    public void RemoveBonusStat(int valToRemove, string str)
    {
        BaseStats baseStat = FindBaseStat(str);
        baseStat = baseStats.Find(x => x.ValueType.CompareTo(str) == 0);
        if(baseStat != null)
        {
            baseStat.RemoveBonusValue(valToRemove);
        }
    }

}
