using System.Collections.Generic;
using UnityEngine;

namespace SleepyKuma.Inventory
{
public class InventoryManager : MonoBehaviour 
{
    [SerializeField] public ItemsData itemsData;
    [SerializeField] public InventoryUI inventoryUI;

    private const string InventoryKey = "InventoryData";

    

    public void AddItem(ItemsData item)
    {
        itemsData = item;
        
        if (inventoryUI != null)
        {
            inventoryUI.UpdateUI(item);
        }

        Debug.Log("add item inv mngr");

        SaveInventoryData();
    }

    void SaveInventoryData()
    {
        string jsonData = JsonUtility.ToJson(itemsData);
        PlayerPrefs.SetString(InventoryKey, jsonData);
        PlayerPrefs.Save();

        Debug.Log("save");
    }

    public void LoadInventoryData()
    {
        if (PlayerPrefs.HasKey(InventoryKey))
        {
            string jsonData = PlayerPrefs.GetString(InventoryKey);
            itemsData = JsonUtility.FromJson<ItemsData>(jsonData);
            
            if (itemsData != null)
            {
                if (inventoryUI != null)
                {
                    inventoryUI.UpdateUI(itemsData);
                    Debug.Log("load");
                }
            }
        }
    }
    

    // public bool HasItem(ItemsData item)
    // {
    //     if(itemsData.Contains(item)) return true;
    //     return false;
    // }

    // public void RemoveItem(ItemsData item)
    // {
    //     if(itemsData.Contains(item))
    //     {
    //         itemsData.Remove(item);
    //     }
    // }
}
}