using System.Collections;
using System.Collections.Generic;
using SleepyKuma.Interactive;
using UnityEngine;
using UnityEngine.EventSystems;
using cherrydev;//buat dialog

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4f;
    [SerializeField]
    private float runSpeed = 8f;
    [SerializeField]
    public float jumpForce = 10f;
    [SerializeField]
    private float doubleClickTime = 2f;
    [SerializeField]
    public Animator animator;
    public bool isMoving = false;
    private bool isJumping = false;
    private bool isRunning = false;
    public bool isGround = true;
    private Vector3 targetPosition;
    private SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    private float lastClickTime = 0f;
    public Interactor interactor;

    [Header("Dialog")]
    public bool dialogPlay = false;
    public static CharacterMovement Instance;

    //ini juga buat dialog ya
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Stop()
    {
        isMoving = false;
        animator.SetBool("ismoving", false);
        isRunning = false;
        animator.SetBool("isrunning", false);
    }

    private void Update()
    {
        animator.SetBool("turn", true);

        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            lastClickTime = Time.time;

            if (timeSinceLastClick <= doubleClickTime)
            {
                // Handle double click to run
                isRunning = true;
                animator.SetBool("isrunning", true);
            }
            else
            {
                // Handle single click to move
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = 0f;
                isMoving = true;

                if (!dialogPlay)
                {
                    FlipCharacter(targetPosition - transform.position);
                }

                animator.SetBool("isrunning", false);
                animator.SetBool("ismoving", true);
            }

        }

        if (dialogPlay)
        {
            Stop();
        }

        if (isMoving)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                animator.SetBool("ismoving", false);
            }
        }

        if (isRunning)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.Translate(moveDirection * runSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
            {
                isRunning = false;
                animator.SetBool("isrunning", false);
            }
        }
    }

    public void FlipCharacter(Vector3 direction)
    {

        if (direction.x > 0)
        {
            if (spriteRenderer.flipX == true)
            {
                animator.SetBool("isrunning", false);
                animator.SetBool("ismoving", false);
            }
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            if (spriteRenderer.flipX == false)
            {
                animator.SetBool("isrunning", false);
                animator.SetBool("ismoving", false);
            }
            spriteRenderer.flipX = true;
        }
    }
}