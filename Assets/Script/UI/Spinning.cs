using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spinning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 0, -360), 3f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetUpdate(true).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
