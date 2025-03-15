using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHideTarget : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerComponent playerComponent;
    [SerializeField] private SpriteRenderer bushObject;
    [SerializeField] private BushAnimator bushAnimator;
    
    [SerializeField] private bool hiding;

    private void Start()
    {
        playerComponent = FindObjectOfType<PlayerComponent>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        hiding = playerMovement.isHiding; 
    }

    public void Close()
    {
        UnHide();
    }

    public void UnHide()
    {
        hiding = false;
        
        bushAnimator.BushIdle();
        bushObject.sortingOrder = 0;

        playerComponent.SpriteEnabled();
        playerComponent.TagUnhide();
    }

    public void Hide()
    {
        hiding = true;

        bushObject.sortingOrder = 2;
        bushAnimator.BushHide();
        playerComponent.SpriteDisable();
        playerComponent.TagHide();
    }
}
