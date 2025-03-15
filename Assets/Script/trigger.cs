using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trigger : MonoBehaviour
{
    [SerializeField] private GameObject loseCondition;
    [SerializeField] private GameObject loseCutscene;
    [SerializeField] private GameObject stageSatu;

    private int clickCount = 0;
    private bool next = false;
    private PlayerCollisionLayer playerCollisionLayer;
    private PlayerDeath playerDeath;

    private void Start()
    {
        playerCollisionLayer = FindObjectOfType<PlayerCollisionLayer>();
        playerDeath = FindObjectOfType<PlayerDeath>();
    }

    void Update()
    {
        // if (playerCollisionLayer.TriggerLose()) 
        // {
        //     // SceneManager.LoadScene("stage1");
        //     loseCutscene.SetActive(true);
        //     stageSatu.SetActive(false);
        //     next = true;
        // }

        // if(next)
        // {
        //     Click();
        // }
    }

    public void Click()
    {
        loseCondition.SetActive(true); 
    }   
}
