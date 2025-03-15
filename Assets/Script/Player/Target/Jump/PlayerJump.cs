using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    [SerializeField] private PlayerMovement playerMovement;
    public bool isJumping;

    [SerializeField] private float jumpDuration = 2.0f;
    
    public void Jump(Vector3 target, Action onArrive = null)
    {
        isJumping = true;
        playerMovement.playerAnimator.Jump();
        
        transform.DOJump(target, 1f, 1, jumpDuration).OnComplete(() => {
            playerMovement.moveTarget = transform.position;
            isJumping = false;
            playerMovement.playerAnimator.Land();
            onArrive?.Invoke();
        }).OnUpdate(() =>
        {
            if (Vector3.Distance(transform.position, target) < 2f)
            {
                playerMovement.playerAnimator.Landing();
            }
            playerMovement.CheckObjectDirection();
        }).SetEase(Ease.Linear);
        
    }
}