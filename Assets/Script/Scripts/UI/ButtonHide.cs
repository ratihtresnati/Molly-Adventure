// using UnityEngine;
// using UnityEngine.UI;
// using SleepyKuma.Dialog;

// public class ButtonHide : MonoBehaviour 
// {
//     public Button buttonHide;
//     public bool showDialog = true;
//     [SerializeField] private DialogueUI dialog;

//     private void Start()
//     {
//         buttonHide.onClick.AddListener(OnClick);
//        // DialogueUI dialog = dialogUI.GetComponent<DialogueUI>(); 
//     }

//     private void OnClick()
//     {
//         if (showDialog)
//         {
//             dialog.gameObject.SetActive(false);
//             showDialog = false;
//             dialog.ResumeTextAnimation();
//         }
//         else
//         {
//             dialog.gameObject.SetActive(true);
//             showDialog = true;
//             dialog.PauseTextAnimation();
//         }
//     }
// }