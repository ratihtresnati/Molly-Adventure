using cherrydev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SleepyKuma
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private DialogBehaviour dialogBehaviour;
        [SerializeField] private DialogNodeGraph dialogNodeGraph;

        private bool allowInteract;


        private void OnTriggerEnter2D(Collider2D collision)
        {

            allowInteract = true;

        }

        private void OnTriggerExit2D(Collider2D collision)
        {

            allowInteract = false;
        }

        private void Update()
        {
            if (allowInteract && Input.GetMouseButtonDown(0)) dialogBehaviour.StartDialog(dialogNodeGraph);   
        }
    }
}
