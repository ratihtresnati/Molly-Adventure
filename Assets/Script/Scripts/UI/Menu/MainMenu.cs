using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{

    public UnityEvent startDialogueEvent;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingMenu;
    [SerializeField] private GameObject tutorialMenu;
    [SerializeField] private GameObject loadMenu;
    [SerializeField] private GameObject creditMenu;
    [SerializeField] private GameObject confirmationMenu;

    [SerializeField] private HealthBar healthBar;

    public bool yes;

    void Start()
    {
        startDialogueEvent.Invoke();
        healthBar = FindObjectOfType<HealthBar>();
    }

    public void LoadStage()
    {
        if (GameManager.Instance != null)
        {
            GameManager.LoadStage();
            if (healthBar != null)
            {
                healthBar.ResetHealth();
            }
        }
    }

    public void LoadLevel(string scene)
    {
        if (GameManager.Instance != null && scene != null)
        {
            GameManager.ChangeScene(scene);
        }
    }

    public void ButtonSetting()
    {
        mainMenu.SetActive(false);
        settingMenu.SetActive(true);
    }

    public void ButtonTutorial()
    {
        tutorialMenu.SetActive(true);
        settingMenu.SetActive(false);
    }

    public void ButtonLoad()
    {
        settingMenu.SetActive(false);
        loadMenu.SetActive(true);
    }

    public void ButtonCredit()
    {
        settingMenu.SetActive(false);
        creditMenu.SetActive(true);
    }



    public void BackSetting()
    {
        mainMenu.SetActive(true);
        settingMenu.SetActive(false);
    }

    public void BackTutorial()
    {
        tutorialMenu.SetActive(false);
        settingMenu.SetActive(true);
    }

    public void BackLoad()
    {
        settingMenu.SetActive(true);
        loadMenu.SetActive(false);
    }

    public void BackCredit()
    {
        settingMenu.SetActive(true);
        creditMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void YesButton()
    {
        yes = true;
        Confirmation();
    }

    public void NoButton()
    {
        yes = false;
        Confirmation();
    }

    public void ConfirmationMenu()
    {
        confirmationMenu.SetActive(true);
    }

    public void Confirmation()
    {
        if (!yes)
        {
            Debug.Log("gak jadi dh");
            confirmationMenu.SetActive(false);
        }
        else
        {
            Application.Quit();
            Debug.Log("keluar");
        }
    }

}
