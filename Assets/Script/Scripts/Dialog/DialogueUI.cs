using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SleepyKuma.Dialog
{
    
    public class DialogueUI : MonoBehaviour
    {
        #region Singleton

        public static DialogueUI instance { get; private set; }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
//                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion

        private DialogueManager currentDialogueManager;

        [Header("References")]
        [SerializeField] private Image portrait;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private GameObject dialogueWindow;
        //[SerializeField] private ButtonHide hideButton;

        [Header("Settings")]
        [SerializeField] private bool animateText = true;
        [SerializeField] private bool showAllText = false;

        [Range(0.1f, 1f)]
        [SerializeField] private float textAnimationSpeed = 0.5f;

         private bool lastSentenceDisplayed = false;
         private bool isWritingText = false;

        private void Start()
        {
            //Hide dialogue and interaction UI at start
            dialogueWindow.SetActive(false);
            //interactionUI.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
               if (showAllText && !animateText && currentDialogueManager != null)
                {
                    // Show the next sentence
                    // NextSentence();
                    currentDialogueManager.ShowCurrentSentence();
                    currentDialogueManager.audioSource.Stop();
                    animateText = true;
                    showAllText = false;
                    Debug.Log("next");
                }
                else if (!showAllText && animateText)
                {
                    // currentDialogueManager.ShowCurrentSentence();
                    NextSentence();
                    animateText = false;
                    showAllText = true;
                    Debug.Log("all");
                }
            }
        }

        public void resetBool()
        {
            showAllText = false;
            animateText = true;
        }
        
        public void NextSentence()
        {
            //Continue only if we have dialogue
            if (currentDialogueManager == null)
                return;

            //Tell the current dialogue manager to display the next sentence. This function also gives information if we are at the last sentence
            currentDialogueManager.NextSentence(out bool lastSentence);

            //If last sentence remove current dialogue manager
            if (lastSentence)
            {
                currentDialogueManager = null;
                lastSentenceDisplayed = true;

                resetBool();

                // Check if there is an audio source attached to the current dialogue manager
                if (currentDialogueManager != null && currentDialogueManager.audioSource != null)
                {
                    // Stop the audio playback
                    currentDialogueManager.audioSource.Stop();
                } else
                {
                    lastSentenceDisplayed = false;
                }
            }
        }

        public void StartDialogue(DialogueManager _dialogueManager)
        {
            //Store dialogue manager
            currentDialogueManager = _dialogueManager;

            resetBool();

            //Start displaying dialogue
            currentDialogueManager.StartDialogue();
        }

        public void ShowSentence(DialogueCharacter _dialogueCharacter, string _message)
        {
            StopAllCoroutines();

            dialogueWindow.SetActive(true);

            portrait.sprite = _dialogueCharacter.characterPhoto;
            nameText.text = _dialogueCharacter.characterName;

            if (showAllText == true)
            {
                messageText.text = _message;
                Debug.Log("showalltect");
            } 
            else if (animateText == true)
            {
                StartCoroutine(WriteTextToTextmesh(_message, messageText));
                showAllText = true;
                Debug.Log("animatetext");
            }
        }

        public void ClearText()
        {
            dialogueWindow.SetActive(false);

        }

        public void ShowInteractionUI(bool _value)
        {
            //interactionUI.SetActive(_value);
        }

        IEnumerator WriteTextToTextmesh(string _text, TextMeshProUGUI _textMeshObject)
        {
            _textMeshObject.text = "";
            char[] _letters = _text.ToCharArray();

            float _speed = 1f - textAnimationSpeed;

            foreach(char _letter in _letters)
            {
                _textMeshObject.text += _letter;
                yield return new WaitForSeconds(0.1f * _speed);
            }

            if (currentDialogueManager != null && currentDialogueManager.audioSource != null)
            {
                currentDialogueManager.audioSource.Stop();
            }
            
            showAllText = false;
            animateText = true;
        }

    }
}
