using UnityEngine;

public class BushAnimator : MonoBehaviour {
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void BushIdle()
    {
        animator.SetBool("Hide", false);
    }

    public void BushHide()
    {
        animator.SetBool("Hide", true);
    }
}