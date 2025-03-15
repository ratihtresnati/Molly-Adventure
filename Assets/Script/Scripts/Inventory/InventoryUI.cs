using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SleepyKuma.Inventory
{
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    private ItemsData itemsData;
    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();

            if (inventoryManager.itemsData != null)
            {
                UpdateUI(inventoryManager.itemsData);
            }
    }

    public void UpdateUI(ItemsData itemsData)
    {
        itemImage.sprite = itemsData.itemPhoto;
        Debug.Log("update UI");
    }
}
}