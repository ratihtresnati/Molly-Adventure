using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    public AudioClip[] footstepAudio;
    public AudioClip[] jumpAudio;
    public AudioClip[] hideAudio;
    public AudioSource characterAudio;
    public void PlayFootstep()
    {
        characterAudio.PlayOneShot(footstepAudio[Random.Range(0,footstepAudio.Length)]);
    }
    public void PlayJump()
    {
        characterAudio.PlayOneShot(jumpAudio[Random.Range(0, jumpAudio.Length)]);
    }
    public void PlayHide()
    {
        characterAudio.PlayOneShot(hideAudio[Random.Range(0, hideAudio.Length)]);
    }
}
