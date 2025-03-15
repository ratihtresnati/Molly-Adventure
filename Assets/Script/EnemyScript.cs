using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;
    public GameObject npc;
    public GameObject enemy;
    public Animator enemyAnimator;

    float npcSpawnInterval = 1.8f;
    float enemySpawnInterval = 2.355f;
    private bool initialEnemySpawned = false;
    private bool detect;

    private PlayerAnimator playerAnimator;
    private PlayerDeath playerDeath;
    private HealthBar healthBar;
    private PlayerCollisionLayer playerCollisionLayer;

    void Start()
    {
        playerDeath = FindObjectOfType<PlayerDeath>();
        StartCoroutine(SpawnInitialEnemy());
        StartCoroutine(SpawnNPCEnemyRoutine());

        playerAnimator = FindObjectOfType<PlayerAnimator>();
        healthBar = FindObjectOfType<HealthBar>();
        playerCollisionLayer = FindObjectOfType<PlayerCollisionLayer>();
    }

    IEnumerator SpawnInitialEnemy()
    {
        if (!initialEnemySpawned)
            initialEnemySpawned = true;

        yield return new WaitForSeconds(0.7f);

        npc.SetActive(true);
        enemy.SetActive(true);
        CheckPlayerDistance();  // Call this during the initial spawn.
    }

    IEnumerator SpawnNPCEnemyRoutine()
    {
        while (true)
        {
            npc.SetActive(true);
            enemy.SetActive(false);
            CheckPlayerDistance();  // Call this when NPC is active.
            yield return new WaitForSeconds(npcSpawnInterval);

            enemy.SetActive(true);
            CheckPlayerDistance();  // Call this when enemy is active.
            yield return new WaitForSeconds(enemySpawnInterval);
        }
    }

    public void EnemyDetection()
    {
        // PlayerHide playerHideTarget = FindObjectOfType<PlayerHide>();

        // if(!playerHideTarget.isHiding)
        //     {
                EnemyDetectionLayer("deathLayer");
          //  }
    }

    public void EnemyDetectionHide()
    {
        // PlayerHide playerHideTarget = FindObjectOfType<PlayerHide>();

        // if(playerHideTarget.isHiding) 
        //     {
                EnemyDetectionLayer("UI");
          //  }
    }

    void CheckPlayerDistance()
    {   
        if (player != null && enemy.activeSelf)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
           
            //if (distance < 1.5f)
            if(distance < 1.5f && playerCollisionLayer.TriggerLose())
            {
                //PlayerCaught();
                healthBar.Die();
            }

            if (playerDeath.isDie)
            {
                EnemyAngry();
            }
        }
    }

    void PlayerCaught()
    {
        HealthManager.health--;
        HealthManager healthManager = player.GetComponent<HealthManager>();

        if (HealthManager.health <= 0)
        {
            enemyAnimator.SetBool("marah", true);
            // Nonaktifkan pemain tanpa menggunakan coroutine
            //player.SetActive(false);

            playerAnimator.Shock();
            StartCoroutine(playerDeath.Dying());

            if (PlayerMovement.Instance != null)
            {
                PlayerMovement.Instance.dialogPlay = true;
            }

        }
    }

    public void EnemyAngry()
    {
        enemyAnimator.SetBool("marah", true);
    }

    private void EnemyDetectionLayer(string layerName)
    {
        enemy.layer = LayerMask.NameToLayer(layerName);
    }
}
