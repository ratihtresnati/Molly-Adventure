using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelTutorial : MonoBehaviour {

    public static PanelTutorial Instance;

    [Header("Items")]
    [SerializeField] private Image tutorialImage;
    [SerializeField] private TextMeshProUGUI nameTutorial;
    [SerializeField] private TextMeshProUGUI keteranganTutorial;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowItemsGet(ScriptableTutorial tutorial)
    {
        if (tutorialImage != null) {
            tutorialImage.sprite = tutorial.tutorialPhoto;
        }
        nameTutorial.text = tutorial.tutorialName;
        keteranganTutorial.text = tutorial.keterangan;
    }
}