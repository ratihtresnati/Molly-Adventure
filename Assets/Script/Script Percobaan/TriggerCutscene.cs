using UnityEngine;

public class TriggerCutscene : MonoBehaviour
{
    public CutsceneManager cutsceneManager;

    public void StartCutscene()
    {
        // Trigger your cutscene here
        cutsceneManager.PlayCutscene();
    }
}