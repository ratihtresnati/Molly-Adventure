using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    //movement player
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float runSpeed = 2f;
    [SerializeField] private bool lockY;

    public Vector3 moveTarget;
    private Camera cam;
    private Vector3 previousPosition;
    private float previousX;
    private float moveSpeed; 
    private float speed;
    
    [HideInInspector] public PlayerAnimator playerAnimator;
    private PlayerFall playerFall;
    private PlayerJump playerJump;
    private PlayerCollisionLayer playerCollisionLayer;

    [HideInInspector] public bool isHiding;

    public bool dialogPlay;
    public Action onDialogPlay;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        moveTarget = transform.position;

        playerAnimator = GetComponent<PlayerAnimator>();
        playerFall = GetComponent<PlayerFall>();
        playerJump = GetComponent<PlayerJump>();
        playerCollisionLayer = GetComponent<PlayerCollisionLayer>();

        cam = Camera.main;
        previousPosition = transform.position;
        previousX = transform.position.x;
    }

    private void Update()
    {
        if ((playerJump != null && playerJump.isJumping == true) || dialogPlay)
        {
            return;
        }


        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Input.mousePosition;
            mousePos.z = Vector3.Distance(cam.transform.position, transform.position);

            moveTarget = cam.ScreenToWorldPoint(mousePos);
            moveTarget.z = transform.position.z;
            speed = 1f;
            moveSpeed = runSpeed;
        }

        if (Input.GetMouseButtonDown(1))
        {
            var mousePos = Input.mousePosition;
            mousePos.z = Vector3.Distance(cam.transform.position, transform.position);

            moveTarget = cam.ScreenToWorldPoint(mousePos);
            moveTarget.z = transform.position.z;
            speed = 0f;
            moveSpeed = walkSpeed;
        }

        if (transform.position != previousPosition)
        {
            //Object is Moving
            playerAnimator.ChangeSpeed(speed);
        }
        else
        {
            playerAnimator.Idle();
        }

        previousPosition = transform.position;


        CheckObjectDirection();

        if (lockY)
        {
            Vector3 target = new Vector3(moveTarget.x, transform.position.y, transform.position.z);
            Move(target);
            PlayerFalling();
        }
        else
        {
            Vector3 target = new Vector3(moveTarget.x, moveTarget.y, transform.position.z);
            Move(target);
        }
        
     }

    private void PlayerFalling()
    {
        if (playerFall != null && playerCollisionLayer != null)
        {
            if (!playerCollisionLayer.IsGrounded())
            {
                playerFall.Falling();    
            }
        }
    }

    // public void CheckObjectDirection()
    // {

    //     float currentX = transform.position.x;

    //     if (currentX < previousX)
    //     {
    //         playerAnimator.TurnLeft();
    //        FlipSprite(true);
    //     }
    //     else if (currentX > previousX)
    //     {
    //         playerAnimator.TurnRight();
    //         FlipSprite(false);
    //     }

    //     previousX = currentX;

    // }

    public void CheckObjectDirection()
    {
        float currentX = transform.position.x;
        if (currentX < previousX)
        {
            playerAnimator.TurnLeft();
        }
        else if (currentX > previousX)
        {
            playerAnimator.TurnRight();
        }
        previousX = currentX;
    }

    // private void FlipSprite(bool faceLeft)
    // {
    //     // Assuming your player sprite is a child object with a SpriteRenderer component
    //     SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();


    //     if (spriteRenderer != null)
    //     {
    //         spriteRenderer.flipX = faceLeft;
    //     }
    // }


    private void OnEnable()
    {
        onDialogPlay += StopMovementAnimation;
    }

    private void OnDisable()
    {
        onDialogPlay -= StopMovementAnimation;
    }

    private void StopMovementAnimation()
    {
        playerAnimator.Stop();
    }

    public void AllowMove()
    {
        dialogPlay = false;
    }

    public void DisallowMove()
    {
        dialogPlay = true;
    }


    public void Move(Vector3 target)
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = target - currentPosition;

        RaycastHit2D hit = Physics2D.Raycast(currentPosition, direction, playerCollisionLayer.detectionDistance, playerCollisionLayer.groundMask);

        if (hit.collider == null)
        {
            // No obstacle detected, move towards the target
            transform.position = Vector3.MoveTowards(currentPosition, target, moveSpeed * Time.deltaTime);
        }

    }
}
