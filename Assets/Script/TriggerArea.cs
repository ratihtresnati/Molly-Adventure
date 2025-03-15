using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float areaDistance = 1f;

    public bool isTriggering;

    [SerializeField] private UnityEvent onTriggerEnter;
    [SerializeField] private UnityEvent onTriggerExit;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < areaDistance)
        {
            if (!isTriggering)
            {
                isTriggering = true;
                onTriggerEnter?.Invoke();
            }
            
        }
        else
        {
            if (isTriggering)
            {
                isTriggering = false;
                onTriggerExit?.Invoke();
            }
        }
        
    }

    public void Tertrigger()
    {
        isTriggering = false;
    }
}
