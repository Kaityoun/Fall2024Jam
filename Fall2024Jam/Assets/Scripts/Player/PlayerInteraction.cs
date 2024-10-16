using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ScaredyKat.Interactables;

namespace ScaredyKat.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        private Interactable currentInteractable;

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

        // Optional: A method to set the currentInteractable when the player is in the interactable zone
        public void SetCurrentInteractable(Interactable interactable)
        {
            currentInteractable = interactable;
        }
    }
}
