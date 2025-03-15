using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SleepyKuma.Inventory;

public class PanelWin : MonoBehaviour {

    public static PanelWin Instance;

    [Header("Items")]
    [SerializeField] private Image itemsImage;
    [SerializeField] private TextMeshProUGUI nameItems;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowItemsGet(ItemsData itemsData)
    {
        itemsImage.sprite = itemsData.itemPhoto;
        nameItems.text = itemsData.itemName;
    }
}