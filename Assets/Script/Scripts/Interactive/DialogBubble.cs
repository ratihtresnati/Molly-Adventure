using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using cherrydev;

namespace SleepyKuma.Interactive
{
    public class DialogBubble : MonoBehaviour, IInteractable
    {
        [SerializeField] private DialogBehaviour dialogBehaviour;
        [SerializeField] private DialogNodeGraph dialogNodeGraph;
        public GameObject nextDialogue;
        private Interactor interactor;
        private bool StartDialog;

        public bool Interact(Interactor interactor)
        {
            if (!StartDialog) 
            {
                StartDialog = true; 
                ClickNPC();
                return false;
            }
            return true;
        }

        public void ClickNPC()
        {
            interactor = FindObjectOfType<Interactor>();
            if (interactor != null)
            {
                if(interactor.InteractorCollider().tag == "NPC")
                {
                    dialogBehaviour.StartDialog(dialogNodeGraph);
                }
            }
        }
        
        public void ClickOBject(){}
        public void Hide(){}

        public void nextDialog()
        {
            if (nextDialogue != null)
            {
                nextDialogue.SetActive(true);

                ObjectBubble objectBubble = nextDialogue.GetComponent<ObjectBubble>();
                if (objectBubble != null)
                {
                    objectBubble.Inventory();
                }
            }
        }
    }
}