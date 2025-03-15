using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject barPrefab;
    [SerializeField] private HealthData healthData;
    [SerializeField] private bool deadChangeScreen;
    private PlayerDeath playerDeath;
    private int previousHealth;

    private void Start()
    {
        HealthBarUI();
    }

    void Update()
    {
        if (deadChangeScreen)
        {
            if (healthData.health != previousHealth)
            {
                ResetHealthUI();
                HealthBarUI();
                previousHealth = healthData.health;
            }
        }
    }

    private void HealthBarUI()
    {
        for (int i = 0; i < healthData.health; i++)
        {
            Instantiate(barPrefab, transform);
        }
    }

    private void ResetHealthUI()
    {
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }
    }

    private void OnEnable()
    {
        if(playerDeath == null)
            playerDeath = FindObjectOfType<PlayerDeath>();
        
        playerDeath.onAfterDie.AddListener(Die);
    }

    private void OnDisable()
    {
        playerDeath.onAfterDie.RemoveListener(Die);
    }

    public void Die()
    {
        Debug.Log("Die!!");
        if(healthData.health == 0 )
            return;

        healthData.health -= 1; 
        
        if (healthData.health == 0)
        {
            if (deadChangeScreen) 
            {
                playerDeath.DieShock();
            } else 
            {
                playerDeath.loseCondition.SetActive(true); 
            }              
        }
        else
        {
            //OnDisable();
           if (!deadChangeScreen) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                playerDeath.isDie = false;
            }
        }
        playerDeath.onAfterDie.RemoveListener(Die);
    }

    public void ResetHealth()
    {
        
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         healthData.health = 3;
         playerDeath.isDie = false;
    }

    void OnApplicationQuit()
    {
        healthData.health = 3;
    }
}
