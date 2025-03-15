using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SleepyKuma.Inventory
{
    [CreateAssetMenu(fileName = "New item", menuName = "New Items", order = 0)]
    public class ItemsData : ScriptableObject
    {
        public string itemName;
        public Sprite itemPhoto;
    }
}
