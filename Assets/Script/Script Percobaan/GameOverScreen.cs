using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public TriggerCutscene triggerCutscene;

    private void Start()
    {
        // Hide the Game Over screen initially
        gameObject.SetActive(false);
    }

    public void OnRestartButtonClick()
    {
        // Trigger the cutscene when the restart button is clicked
        triggerCutscene.StartCutscene();
    }
}