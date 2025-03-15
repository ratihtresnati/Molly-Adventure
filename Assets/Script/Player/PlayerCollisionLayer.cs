using System.Collections;
using UnityEngine;

public class PlayerCollisionLayer : MonoBehaviour
{
    [Header("Layer Ground")]
    [SerializeField] public LayerMask groundMask;
    [SerializeField] public float detectionDistance = 0.2f;

    [Header("Layer Death")]
    [SerializeField] public LayerMask deathLayer; 
    [SerializeField] public float deathDistance = 1f; 

    [Header("Layer Lose")]
    [SerializeField] public LayerMask loseLayer; 
    [SerializeField] public float loseDistance = 1f; 

    public bool IsDeadlyObjectBelow()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, deathDistance, deathLayer);
        return hit.collider != null;
    }

    public bool IsGrounded()
    {
        // Raycast downward to check if there's ground beneath the player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, detectionDistance, groundMask);
        return hit.collider != null;
    }

    public bool TriggerLose()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, loseDistance, loseLayer);
        return hit.collider != null;
    }
}