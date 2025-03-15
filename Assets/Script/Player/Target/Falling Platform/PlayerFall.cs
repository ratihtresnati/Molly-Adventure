using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Molly.Falling;

public class PlayerFall : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 3f;
    [SerializeField] private FallingPlatform fallingPlatform;
    [SerializeField] private bool isPlayerOnPlatform;
    private PlayerDeath playerDeath;
    private PlayerAnimator playerAnimator;
    private PlayerCollisionLayer playerCollisionLayer;
    private PlayerJump playerJump;

    private void Start()
    {
        playerDeath = GetComponent<PlayerDeath>();
        playerCollisionLayer = GetComponent<PlayerCollisionLayer>();
        playerJump = GetComponent<PlayerJump>();
    }

    public void Falling()
    {
        Fall();
    }

    private void Fall()
    {
        // Implementasi perilaku jatuh sesuai kebutuhan permainan Anda.
        // Misalnya, ubah posisi karakter ke bawah atau mainkan animasi jatuh.
        if (!playerJump.isJumping)
        {   
            transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
            Debug.Log("hai");
        }

            isPlayerOnPlatform = playerCollisionLayer.IsGrounded() && playerCollisionLayer.IsDeadlyObjectBelow();
            if (fallingPlatform != null)
            {
                if (isPlayerOnPlatform && !fallingPlatform.isFalling) fallingPlatform.Falling();
                if (fallingPlatform.isFalling) playerDeath.DieFall();
            }
    }
}