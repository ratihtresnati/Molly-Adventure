using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using SleepyKuma.Interactive;

namespace cherrydev
{
    public class DialogBehaviour : MonoBehaviour
    {
        [SerializeField] private float dialogCharDelay;
        [SerializeField] private UnityEvent onDialogStart;
        [SerializeField] private UnityEvent onDialogFinished;

        private DialogNodeGraph currentNodeGraph;
        //[SerializeField] private DialogBubble dialogBubble;
        private Node currentNode;

        public static event Action OnSentenceNodeActive;

        public static event Action OnDialogSentenceEnd;

        public static event Action<string, Sprite> OnSentenceNodeActiveWithParameter;

        public static event Action OnAnswerNodeActive;

        public static event Action<int, AnswerNode> OnAnswerButtonSetUp;

        public static event Action<int> OnAnswerNodeActiveWithParameter;

        public static event Action<int, string> OnAnswerNodeSetUp;

        public static event Action<char> OnDialogTextCharWrote;

        [Header("References")]
        [SerializeField] public AudioSource audioSource;
        public AudioClip sentenceSound;

        /// <summary>
        /// Start a dialog
        /// </summary>
        /// <param name="dialogNodeGraph"></param>
        public void StartDialog(DialogNodeGraph dialogNodeGraph)
        {
            if (dialogNodeGraph.nodesList == null)
            {
                Debug.LogWarning("Dialog Graph's node list is empty");
                return;
            }

            onDialogStart?.Invoke();

            if (PlayerMovement.Instance != null)
            {
                PlayerMovement.Instance.dialogPlay = true;
                PlayerMovement.Instance.onDialogPlay.Invoke();
            }

            if (PauseMenuUI.Instance != null)
            {
                PauseMenuUI.Instance.ClickDisable();
            }

            currentNodeGraph = dialogNodeGraph;
            currentNode = currentNodeGraph.nodesList[0];

            HandleDialogGraphCurrentNode(currentNode);
        }

        /// <summary>
        /// Processing dialog current node
        /// </summary>
        /// <param name="currentNode"></param>
        private void HandleDialogGraphCurrentNode(Node currentNode)
        {
            StopAllCoroutines();

            if (currentNode.GetType() == typeof(SentenceNode))
            {
                SentenceNode sentenceNode = (SentenceNode)currentNode;

                OnSentenceNodeActive?.Invoke();
                OnSentenceNodeActiveWithParameter?.Invoke(sentenceNode.GetSentenceCharacterName(),
                    sentenceNode.GetCharacterSprite());

                WriteDialogText(sentenceNode.GetSentenceText());
            }
            else if (currentNode.GetType() == typeof(AnswerNode))
            {
                AnswerNode answerNode = (AnswerNode)currentNode;
                int amountOfActiveButtons = 0;

                OnAnswerNodeActive?.Invoke();

                for (int i = 0; i < answerNode.childSentenceNodes.Length; i++)
                {
                    if (answerNode.childSentenceNodes[i] != null)
                    {
                        OnAnswerNodeSetUp?.Invoke(i, answerNode.answers[i]);
                        OnAnswerButtonSetUp?.Invoke(i, answerNode);

                        amountOfActiveButtons++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (amountOfActiveButtons == 0)
                {
                    onDialogFinished?.Invoke();
                    return;
                }

                OnAnswerNodeActiveWithParameter?.Invoke(amountOfActiveButtons);
            }
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


        /// <summary>
        /// Setting currentNode field to Node and call HandleDialogGraphCurrentNode method
        /// </summary>
        /// <param name="node"></param>
        public void SetCurrentNodeAndHandleDialogGraph(Node node)
        {
            currentNode = node;
            HandleDialogGraphCurrentNode(this.currentNode);
        }

        /// <summary>
        /// Writing dialog text
        /// </summary>
        /// <param name="text"></param>
        private void WriteDialogText(string text)
        {
            StartCoroutine(WriteDialogTextRoutine(text));
            PlaySound(sentenceSound);
        }

        /// <summary>
        /// Writing dialog text coroutine
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private IEnumerator WriteDialogTextRoutine(string text)
        {
            foreach (char textChar in text)
            {
                yield return new WaitForSeconds(dialogCharDelay);
                OnDialogTextCharWrote?.Invoke(textChar);
            }
            
            audioSource.Stop();
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));


            OnDialogSentenceEnd?.Invoke();
            
            CheckForDialogNextNode();
        }

        /// <summary>
        /// Checking is next dialog node has a child node
        /// </summary>
        private void CheckForDialogNextNode()
        {
            if (currentNode.GetType() == typeof(SentenceNode))
            {
                SentenceNode sentenceNode = (SentenceNode)currentNode;

                if (sentenceNode.childNode != null)
                {
                    currentNode = sentenceNode.childNode;
                    HandleDialogGraphCurrentNode(currentNode);
                }
                else
                {
                    DialogBubble dialogBubble = FindObjectOfType<DialogBubble>();
                    onDialogFinished?.Invoke();
                    dialogBubble.nextDialog();

                    if (PlayerMovement.Instance != null)
                    {
                        PlayerMovement.Instance.dialogPlay = false;
                    }
                    if (PauseMenuUI.Instance != null)
                    {
                        PauseMenuUI.Instance.ClickEnable();
                    }
                }
            }
        }

        /// <summary>
        /// Adding listener to OnDialogFinished UnityEvent
        /// </summary>
        /// <param name="action"></param>
        public void AddListenerToOnDialogFinished(UnityAction action)
        {
            onDialogFinished.AddListener(action);
        }
    }
}