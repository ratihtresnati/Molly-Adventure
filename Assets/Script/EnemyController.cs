using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;  // Drag-and-drop objek pemain ke variabel ini di inspector
    private bool isHidden = false;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("ToggleVisibility", 3f, 5f);
    }

    private void ToggleVisibility()
    {
        isHidden = !isHidden;

        if (isHidden)
        {
            // Sembunyikan musuh
            gameObject.SetActive(false);
            PlayHiddenAnimation();
            Invoke("ShowEnemy", 2f);
        }
        else
        {
            // Tampilkan musuh
            gameObject.SetActive(true);
            PlayVisibleAnimation();
        }
    }

    private void ShowEnemy()
    {
        // Munculkan musuh kembali setelah 2 detik
        gameObject.SetActive(true);
        PlayVisibleAnimation();
    }

    private void PlayHiddenAnimation()
    {
        // Atur parameter Animator untuk animasi tersembunyi
        if (animator != null)
        {
            animator.SetBool("IsHidden", true);
        }
    }

    private void PlayVisibleAnimation()
    {
        // Atur parameter Animator untuk animasi terlihat
        if (animator != null)
        {
            animator.SetBool("IsHidden", false);
        }
    }
}