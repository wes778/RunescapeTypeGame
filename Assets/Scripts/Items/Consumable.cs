using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item
{
    public int healAmount;
    public enum ConsumableType { Healing};
    public ConsumableType consumableType;
    public override void Use()
    {
        if(consumableType == ConsumableType.Healing)
        {
            ConsumableManager.instance.Heal(this);
        }
        
    }
}
