using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using SleepyKuma.Inventory;

namespace SleepyKuma.Interactive
{
    public class Interactor : MonoBehaviour
    {
        //interaction
        [Header("Interaction")]
        [SerializeField] private Transform interactionPoint;
        [SerializeField] private float interactionPointRadius = 0.5f;
        [SerializeField] private LayerMask interactableMask;
        private readonly Collider2D[] thisCollider = new Collider2D[3];
        private IInteractable interactable;
        private Camera mainCamera;
        [SerializeField] private int numFound;

        //hide
       // [SerializeField] private PlayerHideTarget playerHideTarget;

        //private PlayerAnimator playerAnimator;
        private void Update()
        {
            ShowBubble();
        }

        private void Awake() 
        {
            //playerHideTarget = FindObjectOfType<PlayerHideTarget>();
           // playerAnimator = FindObjectOfType<PlayerAnimator>();
            mainCamera = Camera.main;
        }

        public void ShowBubble()
        {
            numFound = Physics2D.OverlapCircleNonAlloc(interactionPoint.position, interactionPointRadius, thisCollider, interactableMask);
            if (numFound > 0)
            {
                //show
                interactable = thisCollider[0].GetComponent<IInteractable>();
                if (interactable != null)
                {
                    //TagsCollider();
                    Interaction();
                }
            }
            // else
            // {
            //     //close
            //     //CloseBubble();
            // }
        }

        // private void TagsCollider()
        // {
        //     if(playerHideTarget != null )
        //     {
        //         if (!playerHideTarget.hiding && thisCollider[0].tag == "Hide" && Input.GetMouseButtonDown(1)) 
        //         {
        //             playerHideTarget.Hide();
        //         }
        //     }
            
        // }

        public Collider2D InteractorCollider() // ngambil collider
        {
            return thisCollider[0];
        }

        private void CloseBubble()
        {
            if (interactable != null) //&& playerHideTarget != null)
            {
                interactable = null;
               //
            }
        }

        public void Interaction()
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                ClickSprite();
            }
        }

        private void ClickSprite()
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero, interactableMask);
            if (hit.collider != null)
            {
                interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(this);
                    Debug.Log("click");
                }
            }
        }
        
        private void OnDrawGizmos() 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
        }
    }
}