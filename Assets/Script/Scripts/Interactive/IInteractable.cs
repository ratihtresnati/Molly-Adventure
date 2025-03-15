using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SleepyKuma.Interactive
{
    public interface IInteractable
    {
        public bool Interact(Interactor interactor);
        public void ClickOBject();//untuk objek
        public void ClickNPC();//untuk npc
        public void Hide();//untuk hide
    }
}
