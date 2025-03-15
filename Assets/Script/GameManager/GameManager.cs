using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SleepyKuma.Inventory;

public class GameManager : MonoBehaviour {
    
    public static GameManager Instance { get; private set;}

    public InventoryManager inventoryManager;
    public Loading loading;

     private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        loading = FindObjectOfType<Loading>();
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    public static void ChangeScene(string scene)
    {
        Instance.loading.LoadScene(scene);
        
    }

    public static void LoadStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void LoadItem(ItemsData item)
    {
        if (Instance.inventoryManager != null)
        {
            Instance.inventoryManager.inventoryUI.UpdateUI(item);
        }
    }
}