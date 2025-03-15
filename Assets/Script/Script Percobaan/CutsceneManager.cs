using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CutsceneManager : MonoBehaviour
{
    // Add your cutscene events or actions here
    public UnityEvent onStartCutscene;
    public UnityEvent onEvent1;
    public UnityEvent onEvent2;
    public UnityEvent onEvent3;
    // ...

    // Coroutine to handle the cutscene sequence
    private IEnumerator PlayCutsceneSequence()
    {
        // Trigger the start of the cutscene
        onStartCutscene.Invoke();
        yield return new WaitForSeconds(1f); // You can adjust the delay as needed

        // Trigger additional cutscene events or actions
        onEvent1.Invoke();
        yield return new WaitForSeconds(2f); // Adjust the delay

        onEvent2.Invoke();
        yield return new WaitForSeconds(1.5f); // Adjust the delay

        onEvent3.Invoke();
        // ...

        // End of the cutscene
    }

    // Method to start playing the cutscene
    public void PlayCutscene()
    {
        StartCoroutine(PlayCutsceneSequence());
    }
}