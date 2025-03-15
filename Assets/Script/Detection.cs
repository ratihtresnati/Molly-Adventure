using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detection : MonoBehaviour
{
    [SerializeField] private float minDistance = 4f;
    [SerializeField] private Transform player;
    [SerializeField] private UnityEvent onDetected;

    private bool detected;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < minDistance)
        {
            if(!detected)
            {
                detected = true;
                Debug.Log("TERDETEKSI!");
                onDetected?.Invoke();
            }

        }
        else
        {
            if (detected)
            {
                detected = false;
                Debug.Log("LOH KOK HILANG!");
            }
        }
    }
}
