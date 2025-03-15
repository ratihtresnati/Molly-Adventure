using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SleepyKuma.Interactive;

namespace SleepyKuma.Dialog
{
    public class DialogueManager : MonoBehaviour
    {   
        [SerializeField] private bool noNeedClick;
        private int currentSentence;
        private float coolDownTimer;
        private bool dialogueIsOn;

        [Header("References")]
        [SerializeField] public AudioSource audioSource;

        [Header("Events")]
        public UnityEvent startDialogueEvent;
        public UnityEvent nextSentenceDialogueEvent;
        public UnityEvent endDialogueEvent;

        [Header("Dialogue")]
        [SerializeField] private List<NPC_Centence> sentences = new List<NPC_Centence>();

        

        private void Update()
        {
            //Timer
            if(coolDownTimer > 0f)
            {
                coolDownTimer -= Time.deltaTime;
            }

            //Start dialogue by input

            // if (!needCLick)
            // {
            //     return;
            // }

            if (!dialogueIsOn && !noNeedClick && Input.GetMouseButtonDown(0))
            {
                Dialogue();
            }

            if (!dialogueIsOn && noNeedClick)
            {
                Dialogue();
            }
        }

        private void Dialogue()
        {
            startDialogueEvent.Invoke();

            //If component found start dialogue
            DialogueUI.instance.StartDialogue(this);

            //Hide interaction UI
            //DialogueUI.instance.ShowInteractionUI(false);

            dialogueIsOn = true;
        }

        public void StartDialogue()
        {
            if (PlayerMovement.Instance != null)
            {
                PlayerMovement.Instance.dialogPlay = true;
                PlayerMovement.Instance.onDialogPlay.Invoke();
            }

            if (PauseMenuUI.Instance != null)
            {
                PauseMenuUI.Instance.ClickDisable();
            }

            //Cooldown timer
            coolDownTimer = 0.5f;

            startDialogueEvent.Invoke();

            //Reset sentence index
            currentSentence = 0;

            //Show first sentence in dialogue UI
            ShowCurrentSentence();

            //Play dialogue sound
            PlaySound(sentences[currentSentence].sentenceSound);
        }

        public void NextSentence(out bool lastSentence)
        {
            //The next sentence cannot be changed immediately after starting
            if (coolDownTimer > 0f)
            {
                lastSentence = false;
                return;
            }

            //Add one to sentence index
            currentSentence++;

            nextSentenceDialogueEvent.Invoke();

            //If last sentence stop dialogue and return
            if (currentSentence > sentences.Count - 1)
            {
                StopDialogue();

                lastSentence = true;

                return;
            }

            //If not last sentence continue...
            lastSentence = false;

            //Play dialogue sound
            PlaySound(sentences[currentSentence].sentenceSound);

            //Show next sentence in dialogue UI
            ShowCurrentSentence();

            //Cooldown timer
            coolDownTimer = 0.5f;

            Debug.Log("hai");
        }

        public void StopDialogue()
        {

            if (PlayerMovement.Instance != null)
            {
                PlayerMovement.Instance.dialogPlay = false;
            }
            if (PauseMenuUI.Instance != null)
            {
                PauseMenuUI.Instance.ClickEnable();
            }


            endDialogueEvent.Invoke();

            //DialogueUI.instance.resetBool(); 

            //Hide dialogue UI
            DialogueUI.instance.ClearText();

            //Stop audiosource so that the speaker's voice does not play in the background
            if(audioSource != null)
            {
                audioSource.Stop();
            }

            //Remove trigger refence
            dialogueIsOn = false;
            
        }

        private void PlaySound(AudioClip _audioClip)
        {
            //Play the sound only if it exists
            if (_audioClip == null || audioSource == null)
                return;

            //Stop the audioSource so that the new sentence does not overlap with the old one
            audioSource.Stop();

            //Play sentence sound
            audioSource.PlayOneShot(_audioClip);
        }

        public void ShowCurrentSentence()
        {
            if (sentences[currentSentence].dialogueCharacter != null)
            {
                //Show sentence on the screen
                DialogueUI.instance.ShowSentence(sentences[currentSentence].dialogueCharacter, sentences[currentSentence].sentence);

                //Invoke sentence event
                sentences[currentSentence].sentenceEvent.Invoke();
            }
            else
            {
                DialogueCharacter _dialogueCharacter = new DialogueCharacter();
                _dialogueCharacter.characterName = "";
                _dialogueCharacter.characterPhoto = null;

                DialogueUI.instance.ShowSentence(_dialogueCharacter, sentences[currentSentence].sentence);
            }
        }
    }

    [System.Serializable]
    public class NPC_Centence
    {
        [Header("------------------------------------------------------------")]

        public DialogueCharacter dialogueCharacter;

        [TextArea(3, 10)]
        public string sentence;

        public AudioClip sentenceSound;

        public UnityEvent sentenceEvent;
    }
}