using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    GameObject[] currentPrefabs;
    public Equipment[] currentEquipment;
    public Transform[] allEquiptTransforms;
    #region Singleton
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one instance of Equipment Manager");
            return;
        }
        instance = this;
    }
    #endregion
    public delegate void OnItemChange(Equipment newItem, Equipment oldItem);
    public OnItemChange onItemChangeCallback;

    public delegate void UpdatingUI();
    public UpdatingUI onUpdatingUICallback;
    //CharacterStats playerStats;

    private void Start()
    {
        currentEquipment = new Equipment[System.Enum.GetNames(typeof(EquiptSlot)).Length];
        currentPrefabs = new GameObject[System.Enum.GetNames(typeof(EquiptSlot)).Length];
        //playerStats = FindObjectOfType<CharacterStats>();

    }
    public void Equipt(Equipment itemToEquipt)
    {
        
        int slotIndex = (int)itemToEquipt.slotToEquipt;
        Equipment oldEquipment = currentEquipment[slotIndex];

        if (currentEquipment[slotIndex] != null)
        {
            
            
            Inventory.instance.Add(oldEquipment);

            Destroy(allEquiptTransforms[slotIndex].GetChild(0).gameObject);
            

        }
        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke(itemToEquipt, oldEquipment);
        }
        currentEquipment[slotIndex] = itemToEquipt;
        currentPrefabs[slotIndex] = itemToEquipt.prefab;
        GameObject prefab = Instantiate(currentPrefabs[slotIndex], allEquiptTransforms[slotIndex].position,allEquiptTransforms[slotIndex].rotation * itemToEquipt.prefab.transform.rotation);
        prefab.transform.SetParent(allEquiptTransforms[slotIndex]);

        prefab.gameObject.GetComponent<ItemPickup>().enabled = false;

        Inventory.instance.Remove(itemToEquipt);
        if(onUpdatingUICallback != null)
        {
            onUpdatingUICallback.Invoke();
        }
        
    }
    public Equipment GetEquipmentInSlot(int slot)
    {
        return currentEquipment[slot];
    }
    public void UnEquipt(Equipment equipment)
    {
        int slotIndex = (int)equipment.slotToEquipt;
        
        if(currentEquipment[slotIndex] != null)
        {
            Inventory.instance.Add(equipment);
            currentEquipment[slotIndex] = null;
            Destroy(allEquiptTransforms[slotIndex].GetChild(0).gameObject);
        }
        if (onUpdatingUICallback != null)
        {
            onUpdatingUICallback.Invoke();
        }
    }

}
