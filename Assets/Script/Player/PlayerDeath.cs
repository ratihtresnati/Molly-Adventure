using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Molly.Falling;

public class PlayerDeath : MonoBehaviour
{
    //player
    private PlayerFall playerFall;
    private PlayerCollisionLayer playerCollisionLayer;

    // [SerializeField] private bool isPlayerOnPlatform;
    [SerializeField] public bool isDie;
    [SerializeField] private UnityEvent onDie;
    [SerializeField] public UnityEvent onAfterDie;
    [SerializeField] public GameObject loseCondition;

    private PlayerAnimator playerAnimator;
    private PlayerDeath playerDeath;


    [SerializeField] private FallingPlatform fallingPlatform;

    private void Start()
    {
        playerFall = GetComponent<PlayerFall>();
        playerCollisionLayer = GetComponent<PlayerCollisionLayer>();
        playerAnimator = FindObjectOfType<PlayerAnimator>();
        playerDeath = FindObjectOfType<PlayerDeath>();
    }

    public void DieFall()
    {
        isDie = true;
        StartCoroutine(Dying());
        playerAnimator.Fall();
        Die();
    }

    public void DieShock()
    {  
        isDie = true;
        StartCoroutine(Dying());
        
        playerAnimator.Shock();
        if (PlayerMovement.Instance != null)
        {
            PlayerMovement.Instance.dialogPlay = true;
        }

        Die();
    }

    public IEnumerator Dying()
    {
        yield return new WaitForSeconds(2f);
        onDie?.Invoke();
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(2f);
        onAfterDie?.Invoke();
    }

}