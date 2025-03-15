using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeDuration = 0.4f;
    public void FadeIn()
    {
        gameObject.SetActive(true);
        canvasGroup.DOFade(1f, fadeDuration);
    }

    public void FadeOut()
    {
        canvasGroup.DOFade(0f, fadeDuration).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
