using DG.Tweening;
using System;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float detectionDistance = 0.2f;
    [SerializeField] private float timeToDestroy = 1.0f;

    private PlayerAnimator playerAnimator;

    private void Start()
    {
        playerAnimator = FindObjectOfType<PlayerAnimator>();
    }

    private void Update()
    {
        if (IsPlayerAbove())
        {
            DestroyPlatform();
        }
    }

    private bool IsPlayerAbove()
    {        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, detectionDistance, playerMask);
        return hit.collider != null;
    }

    public void DestroyPlatform()
    {
        Debug.Log("Fragile Platform destroyed!");
        transform.DOScale(Vector3.zero, timeToDestroy).OnComplete(() =>
        {
            Destroy(gameObject);
            playerAnimator.Fall();
            //ini bisa jatuh kalo ganti layer platformnya idk how
            Debug.Log("Halo");
        });
    }
}