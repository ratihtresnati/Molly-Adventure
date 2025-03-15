using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour {
    //panel
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject savePanel;
    [SerializeField] private GameObject confirmationMenu;

    //button
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject tutorialButton;

    [HideInInspector] public Button menuButtonComponent;
    [HideInInspector] public Button tutorialButtonComponent;

    [SerializeField] private GameObject inventoryUI;
    

    private bool isPaused = false;
    public bool yes;

    public static PauseMenuUI Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        menuButtonComponent = menuButton.GetComponent<Button>();
        tutorialButtonComponent = tutorialButton.GetComponent<Button>(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Menu()
    {
        menuButton.SetActive(false);
        menuPanel.SetActive(true);
        tutorialButton.SetActive(false);
        inventoryUI.SetActive(false);

        PauseGame();
    }

    public void MenuBack()
    {
        menuButton.SetActive(true);
        menuPanel.SetActive(false);
        tutorialButton.SetActive(true);
        inventoryUI.SetActive(true);

        if (PlayerMovement.Instance != null)
            {
                PlayerMovement.Instance.AllowMove();
            }

        Resume();
    }

    public void Tutorial()
    {
        menuButton.SetActive(false);
        tutorialPanel.SetActive(true);
        tutorialButton.SetActive(false);
        inventoryUI.SetActive(false);

        PauseGame();
    }

    public void TutorialBack()
    {
        menuButton.SetActive(true);
        tutorialPanel.SetActive(false);
        tutorialButton.SetActive(true);
        inventoryUI.SetActive(true);

        if (PlayerMovement.Instance != null)
            {
                PlayerMovement.Instance.AllowMove();
            }

        Resume();
    }

    public void Pause()
    {
        if (!isPaused)
        {
            PauseGame();
            menuPanel.SetActive(true);
            menuButton.SetActive(false);
            tutorialButton.SetActive(false);
            inventoryUI.SetActive(false);
        }
        else
        {
            Resume();
            menuPanel.SetActive(false);
            menuButton.SetActive(true);
            tutorialButton.SetActive(true);
            inventoryUI.SetActive(true);
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void ClickEnable()
    {
        menuButtonComponent.interactable = true;
        tutorialButtonComponent.interactable = true;
    }

    public void ClickDisable()
    {
        menuButtonComponent.interactable = false;
        tutorialButtonComponent.interactable = false;
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