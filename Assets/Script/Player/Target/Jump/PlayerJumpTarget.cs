using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class PlayerJumpTarget : MonoBehaviour
{
    [SerializeField] private PlayerJump playerJump;

    [SerializeField] private UnityEvent onArrive;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private float minDistance = 1f;
    [SerializeField] private SpriteRenderer playerJumpSpriteRenderer;
    [SerializeField] private bool useAutoDistanceChecker = false;
    [SerializeField] private bool isActive;

    private bool allowJump;
    private TriggerArea triggerArea;

    public bool UseAutoDistanceChecker
    {
        set { useAutoDistanceChecker = value; }
    }

    public void SetActiveTarget(bool value)
    {
        isActive = value;
        allowJump = value;
        playerJumpSpriteRenderer.enabled = value;
    }

    private void Start()
    {
        playerJump = FindObjectOfType<PlayerJump>();
        triggerArea = FindObjectOfType<TriggerArea>();

        onArrive.AddListener(() =>
        {
            SetActiveTarget(false);
        });
        

        playerJumpSpriteRenderer.enabled = isActive;
        allowJump = isActive;

        if (!isActive)
            return;

        if (useAutoDistanceChecker)
        {
            if (Vector3.Distance(playerJump.transform.position, transform.position) < maxDistance && Vector3.Distance(playerJump.transform.position, transform.position) > minDistance)
            {
                if (playerJumpSpriteRenderer != null) { playerJumpSpriteRenderer.enabled = true; }
            }
            else
            {
                if (playerJumpSpriteRenderer != null) { playerJumpSpriteRenderer.enabled = false; }
            }
        }
        
    }

    private void Update()
    {
        if (useAutoDistanceChecker)
        {
            if (Vector3.Distance(playerJump.transform.position, transform.position) < maxDistance && Vector3.Distance(playerJump.transform.position, transform.position) > minDistance)
            {
                if (!allowJump)
                {
                    allowJump = true;
                    if (playerJumpSpriteRenderer != null) { playerJumpSpriteRenderer.enabled = true; }

                }
                else
                {
                    allowJump = false;
                    if (playerJumpSpriteRenderer != null) { playerJumpSpriteRenderer.enabled = false; }
                }

            }
            else
            {
                allowJump = false;
                if (playerJumpSpriteRenderer != null) { playerJumpSpriteRenderer.enabled = false; }
            }
        }
        
    }

    public void Jump()
    {
        playerJump.Jump(transform.position, () => { onArrive?.Invoke(); });
    }

    private void OnMouseDown()
    {
        if(allowJump && triggerArea != null)
            {  
                if (!triggerArea.isTriggering)
                {
                    Jump(); 
                }
            }
    }
}
