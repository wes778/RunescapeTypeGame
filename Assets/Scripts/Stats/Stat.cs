using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField]
    private int value;
    public List<int> modifiers = new List<int>();
    public int GetValue()
    {
        int finalValue = value;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }
    public void AddModifier(int modifierToAdd)
    {
        if(modifierToAdd != 0)
        {
            modifiers.Add(modifierToAdd);
        }
        
    }
    public void RemoveModifier(int modifierToRemove)
    {
        if(modifierToRemove != 0)
        {
            modifiers.Remove(modifierToRemove);
        }
        
    }
}
