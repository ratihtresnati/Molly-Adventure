using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Idle()
    {
        animator.SetBool("isMoving", false);
        animator.SetBool("isFall", false);
        
    }
    public void ChangeSpeed(float speed)
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("speed", speed);
    }

    public void Stop()
    {
        animator.SetBool("isMoving", false);
        animator.SetFloat("speed", 0f);
    }

    public void TurnRight()
    {
        spriteRenderer.flipX = false;
    }

    public void TurnLeft()
    {
        spriteRenderer.flipX = true;
    }

    public void Jump()
    {
        animator.SetBool("isJumping", true);
    }

    public void Land()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isLanding", false);
    }

    public void Landing()
    {
        animator.SetBool("isLanding", true);
    }

    public void Shock()
    {
        animator.SetBool("isShock", true);
    }

    public void Fall()
    {
        animator.SetBool("isFall", true);
    }

    public void NotFall()
    {
        animator.SetBool("isFall", false);
    }
}
