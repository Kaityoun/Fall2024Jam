using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ScardeyKat.Interactables{

    public class Interactable : MonoBehaviour
    {
        Outline outline;
        public string message;
        public UnityEvent onInteraction;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // Show the UI prompt (implement your UI logic here)
                UIManager.Instance.ShowInteractPrompt(promptMessage);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // Hide the UI prompt
                UIManager.Instance.HideInteractPrompt();
            }
        }

        public void Interact()
        {

            // Implement interaction logic
            Debug.Log($"Interacted with {gameObject.name}");
        }

        public void DisableOutline(){
            outline.enabled = false;
        }

        public void EnableOutline(){
            outline.enabled = true;
        }
    }
}

