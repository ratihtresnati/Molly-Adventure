using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void HideGameOverScreen()
    {
        gameOverScreen.SetActive(false);
    }
}