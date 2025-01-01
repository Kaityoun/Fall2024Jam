using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScaredyKat.Interactables;

namespace ScaredyKat.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        // Change this line to use the interface
        private IInteractable currentInteractable;

        // Instead of OnTriggerEnter/Exit, this will be used when the player presses a key to interact
        private void Update()
        {
            if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Player has pressed to interact");
                // Invoke the interaction event when the player presses E
                currentInteractable.Interact();
            }
        }

        // Update the method to use the interface as the parameter type
        public void SetCurrentInteractable(IInteractable interactable)
        {
            currentInteractable = interactable;
        }
    }
}
