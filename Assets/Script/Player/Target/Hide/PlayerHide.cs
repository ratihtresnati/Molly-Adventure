using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHide : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float areaDistance = 1f;

    public bool isHiding;
    private bool canHide;

    [SerializeField] private UnityEvent onTriggerHiding;
    [SerializeField] private UnityEvent onTriggerUnhide;
    
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < areaDistance)
        {
            canHide = true;
            if (Input.GetMouseButtonDown(1) && canHide == true)
            {
                Debug.Log("24");
                if (!isHiding)
                {
                    isHiding = true;
                    onTriggerHiding?.Invoke();
                }
            }
        }
        else
        {
            if (isHiding)
            {
                isHiding = false;
                canHide = false;
                onTriggerUnhide?.Invoke();
            }
        }
    }
}
