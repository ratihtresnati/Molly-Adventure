using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TutorialDisplay : MonoBehaviour {

    public List<ScriptableTutorial> tutorialSO;
    [SerializeField] private GameObject tutorial;
    private int tutorialNum;

    [SerializeField] private Image[] navImage;
    [SerializeField] private Sprite navClose, navOpen;


    void Start()
    {
        tutorial.SetActive(true);
        PanelTutorial.Instance.ShowItemsGet(tutorialSO[0]);
        // foreach (var item in navImage)
        // {
        //     item.sprite = navClose;
        // }
        ShowNav(0);
    }

    public void Next()
    {
        tutorial.SetActive(false);
        tutorialNum++;
        if (tutorialNum == tutorialSO.Count) tutorialNum = 0;

        PanelTutorial.Instance.ShowItemsGet(tutorialSO[tutorialNum]);
        //navImage[tutorialNum].sprite = navOpen;
        ShowNav(tutorialNum);

        tutorial.SetActive(true);
    }

    public void Back()
    {
        tutorial.SetActive(false);
        tutorialNum--;
        if (tutorialNum == -1) 
        {
            tutorialNum = tutorialSO.Count - 1;
        }

        PanelTutorial.Instance.ShowItemsGet(tutorialSO[tutorialNum]);
        //navImage[tutorialNum].sprite = navOpen;
        ShowNav(tutorialNum);

        tutorial.SetActive(true);
    }

    public void ShowNav(int tutorialNum)
    {

        foreach (var item in navImage)
        {
            item.sprite = navClose;
        } 
        
       if (tutorialNum == tutorialSO.Count)
        {
            tutorialNum = 0;
        }

        navImage[tutorialNum].sprite = navOpen;
    }
}
