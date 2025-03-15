using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Molly.Falling
{
    public class FallingPlatform : MonoBehaviour
{
    //platform
    [SerializeField] private Vector3 initialPosition; // Menyimpan posisi awal platform
    public string layerFall = "UI"; 
    public Animator animator;
    [SerializeField] private float fallDelay = 3f; // Waktu tunggu sebelum platform jatuh
    [SerializeField] private float respawnDelay = 2f; // Waktu tunggu sebelum platform muncul kembali
    [SerializeField] private float fallSpeed = 5f; // Kecepatan jatuh

 //player
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerMask;

    private PlayerAnimator playerAnimator;
    private PlayerDeath playerDeath;


    [SerializeField] public bool isFalling;
    [SerializeField] private UnityEvent fallingPlatform;

   
    void Start()
    {
        initialPosition = transform.position; // Simpan posisi awal saat inisialisasi
        animator = GetComponent<Animator>();
        playerDeath = FindObjectOfType<PlayerDeath>();
    }

    public void Falling()
    {
        fallingPlatform?.Invoke();
    }

    public void fallLing()
    {
        StartCoroutine(FallAfterDelay());
        Debug.Log("52");
    }

    IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(fallDelay);

        // Check again if the player is still on the platform before falling

            FallPlatform();
            yield return new WaitForSeconds(respawnDelay);
            RespawnPlatform();
            Debug.Log("udh nih");   
    }

    public void FallPlatform()
    {
        // Atur posisi platform agar jatuh
        isFalling = true;
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        gameObject.layer = LayerMask.NameToLayer(layerFall);
        animator.SetBool("fragileFall", true);
    }

    void RespawnPlatform()
    {
        // Kembalikan platform ke posisi awal
        transform.position = initialPosition; // Setel kembali ke posisi awal
        isFalling = false;
        gameObject.layer = LayerMask.NameToLayer("fallingPlatform");
        animator.SetBool("fragileFall", false);
    }
}

}
