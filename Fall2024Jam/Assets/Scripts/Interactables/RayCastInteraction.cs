using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScaredyKat.Interactables
{
        public class RaycastInteraction : MonoBehaviour
    {
        public Camera fixedCamera; // Reference to the fixed camera
        public float interactionDistance = 5f; // Distance for interaction
        public LayerMask interactableLayer; // Layer for interactable objects

        private void Update()
        {
            PerformRaycast();
        }

        private void PerformRaycast()
        {
            Ray ray = fixedCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Center of the screen
            RaycastHit[] hits = Physics.RaycastAll(ray, interactionDistance, interactableLayer);
            List<IInteractable> interactableObjects = new List<IInteractable>();

            foreach (var hit in hits)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    float distanceToPlayer = Vector3.Distance(hit.point, transform.position); // Assuming this script is on the player
                    if (distanceToPlayer <= interactionDistance)
                    {
                        interactableObjects.Add(interactable);
                        // Optionally, handle interactions here, e.g., highlighting the object
                    }
                }
            }

            // Optionally process the list of interactable objects
        }
    }
}


