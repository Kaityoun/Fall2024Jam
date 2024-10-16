using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ScaredyKat.Player;

namespace ScaredyKat.Interactables
{
    public class Interactable : MonoBehaviour
    {
        private Outline outline;
        public string message;  // The message to display when interacting
        public UnityEvent onInteraction;

        private void Awake()
        {
            // Find the Outline component on this GameObject
            outline = GetComponent<Outline>();
            if (outline == null)
            {
                Debug.LogError($"Outline component not found on {gameObject.name}.");
            }
        }

        private void Start()
        {
            // Ensure the outline is disabled when the scene starts
            if (outline != null)
            {
                outline.enabled = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // Check if the player entered the trigger
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player entered the interactable zone");
                other.GetComponent<PlayerInteraction>().SetCurrentInteractable(this);
                // Enable outline and show interaction message
                EnableOutline();
                ShowInteractionMessage();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // Check if the player exited the trigger
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player exited the interactable zone");
                other.GetComponent<PlayerInteraction>().SetCurrentInteractable(null);
                // Disable outline and hide interaction message
                DisableOutline();
                HideInteractionMessage();
            }
        }

        public void Interact()
        {
            // Trigger any events bound to the interaction
            onInteraction.Invoke();
            Debug.Log($"Interacted with {gameObject.name}");
        }

        public void DisableOutline()
        {
            if (outline != null)
            {
                outline.enabled = false;
            }
        }

        public void EnableOutline()
        {
            if (outline != null)
            {
                outline.enabled = true;
            }
        }

        public void ShowInteractionMessage()
        {
            HUDController.instance.EnableInteractionText(message);
        }

        public void HideInteractionMessage()
        {
            HUDController.instance.DisableInteractionText();
        }
    }
}

