using System.Collections;
using System.Collections.Generic;
using ScaredyKat.Interactables;
using UnityEngine;

namespace ScaredyKat.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        public CameraRaycaster cameraRaycaster; // Reference to the CameraRaycaster script
        public float interactionDistance = 5f;  // Distance within which the player can interact with objects

        private void Update()
        {
            HandleInteraction();
        }

        // This method handles player interaction with objects detected by the camera
        private void HandleInteraction()
        {
            // Get the interactable objects detected by the camera's precomputed raycast
            // Pass both position and interaction distance to the method
            List<IInteractable> nearbyInteractables = cameraRaycaster.GetInteractablesWithinRange(transform.position, interactionDistance);

            // Check if there are any interactable objects nearby
            if (nearbyInteractables.Count > 0)
            {
                // Find the closest interactable object (if multiple objects are nearby)
                IInteractable closestInteractable = GetClosestInteractable(nearbyInteractables);

                // If the player presses the interaction key (E), interact with the closest object
                if (Input.GetKeyDown(KeyCode.E))
                {
                    closestInteractable.Interact();
                }
            }
        }

        // This method finds the closest interactable object from a list
        private IInteractable GetClosestInteractable(List<IInteractable> interactables)
        {
            IInteractable closest = null;
            float shortestDistance = Mathf.Infinity;

            foreach (IInteractable interactable in interactables)
            {
                // Since we need to get the position from the interactable,
                // we need to cast it to MonoBehaviour first to access the GameObject
                GameObject interactableObject = interactable as MonoBehaviour ? ((MonoBehaviour)interactable).gameObject : null;

                if (interactableObject != null)
                {
                    float distance = Vector3.Distance(interactableObject.transform.position, transform.position); // Distance to player

                    // Check if this object is closer than the previously checked ones
                    if (distance < shortestDistance)
                    {
                        closest = interactable;
                        shortestDistance = distance;
                    }
                }
            }

            return closest;
        }
    }
}
