using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad Instance { get; private set; }

    [SerializeField] private GameObject unitGameObject;
    private IUnit unit;

    // Save slot indices
    private const int SaveSlot1 = 0;
    private const int SaveSlot2 = 1;

    // The current save slot index
    private int currentSaveSlot = SaveSlot1;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Jangan hancurkan objek saat berpindah level
        }
        else
        {
            Destroy(gameObject);
            return; // Keluar dari Awake jika instance sudah ada
        }

        unit = unitGameObject.GetComponent<IUnit>();
    }

    private void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick(null );
        }
    }

    public void HandleMouseClick(SaveSlotButton saveSlotButton)
    {
    // Raycast to detect which UI element was clicked
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
        // Check if the clicked object has a SaveSlotButton component
            saveSlotButton = hit.collider.GetComponent<SaveSlotButton>();

        if (saveSlotButton != null)
        {
            // Set the current save slot based on the clicked button
            currentSaveSlot = saveSlotButton.SaveSlotIndex;

            // Perform any other actions you need when a save slot is selected
            Debug.Log($"Save Slot {currentSaveSlot} selected!");

            // Save or load data based on the clicked save slot
            Save(currentSaveSlot);
            // or Load(currentSaveSlot);
        }
        }
    }

    private void Save(int saveSlot)
    {
        // Save the player's position to the specified save slot
        Vector3 playerPosition = unit.GetPosition();
        SaveVector3($"playerPosition_{saveSlot}", playerPosition);
    }

    private void Load(int saveSlot)
    {
        // Load the player's position from the specified save slot
        Vector3 playerPosition = LoadVector3($"playerPosition_{saveSlot}");

        if (playerPosition != Vector3.zero)
        {
            unit.SetPosition(playerPosition);
        }
        else
        {
            Debug.Log("No Save");
        }
    }

    private void SaveVector3(string key, Vector3 value)
    {
        PlayerPrefs.SetFloat($"{key}X", value.x);
        PlayerPrefs.SetFloat($"{key}Y", value.y);
        PlayerPrefs.SetFloat($"{key}Z", value.z);
        PlayerPrefs.Save();
    }

    private Vector3 LoadVector3(string key)
    {
        float playerPositionX = PlayerPrefs.GetFloat($"{key}X");
        float playerPositionY = PlayerPrefs.GetFloat($"{key}Y");
        float playerPositionZ = PlayerPrefs.GetFloat($"{key}Z");

        return new Vector3(playerPositionX, playerPositionY, playerPositionZ);
    }
}
