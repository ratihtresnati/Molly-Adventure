using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableTutorial", menuName = "Tutorial", order = 0)]
public class ScriptableTutorial : ScriptableObject {
    
    public string tutorialName;
    public Sprite tutorialPhoto;
    public string keterangan;
}

