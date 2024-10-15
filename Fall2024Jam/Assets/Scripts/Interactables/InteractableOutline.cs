using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScaredyKat
{
    public class InteractableOutline : MonoBehaviour
    {
        private Outline outline; 
        public string message;
        public UnityEvent onInteraction;

        // Start is called before the first frame update
        void Start()
        {
            outline = GetComponent<Outline>();
            outline.enabled = false; // Ensure the outline is off initially
        }

        public void Interact()
        {
            onInteraction.Invoke();
        }

        public void DisableOutline()
        {
            outline.enabled = false;
        }

        public void EnableOutline()
        {
            outline.enabled = true;
        }
    }
}
