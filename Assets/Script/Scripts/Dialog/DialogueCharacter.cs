using UnityEngine;

namespace SleepyKuma.Dialog
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Dialogue System/New Dialogue Character", order = 1)]

    public class DialogueCharacter : ScriptableObject
    {
        //nama dan photo character, nanti muncul di dialog
        public Sprite characterPhoto;
        public string characterName;
    }
}