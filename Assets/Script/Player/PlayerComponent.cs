using UnityEngine;

public class PlayerComponent : MonoBehaviour {
    public static PlayerComponent Instance;
    private SpriteRenderer spriteRenderer;
    private CharacterAudio characterAudio;
    private void Awake() 
    {
        Instance = this;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterAudio = GetComponent<CharacterAudio>();
    }
    
    public void SpriteDisable()
    {
        spriteRenderer.enabled = false;
    }

    public void SpriteEnabled()
    {
        spriteRenderer.enabled = true;
    }

    public void TagHide()
    {
        if (gameObject.CompareTag("Player")) gameObject.tag = "PlayerHide";
        characterAudio.PlayHide();
    }

    public void TagUnhide()
    {
        if (gameObject.CompareTag("PlayerHide")) gameObject.tag = "Player";
    }
}