using UnityEngine;
using SleepyKuma.Interactive;

public class InteractHide : MonoBehaviour, IInteractable 
{
    public bool Interact(Interactor interactor)
        {
            //Jump();
            return true;
        }


    public void Hide(){}    
    public void ClickNPC(){}
    public void ClickOBject(){}
}