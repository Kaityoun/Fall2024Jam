using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScaredyKat.Interactables
{
    public class CameraRaycaster : MonoBehaviour
    {
        public Camera fixedCamera;  // The fixed camera
        public LayerMask interactableLayer;  // Layer mask to filter interactable objects

        // Store interactable objects detected by the camera
        private List<IInteractable> interactableObjectsInView = new List<IInteractable>();

        private void Start()
        {
            // Perform the initial raycast when the camera starts or is enabled
            PerformRaycastFromCamera();
        }

        // Call this method when the camera changes or the room is reloaded
        public void OnCameraChange()
        {
            PerformRaycastFromCamera();
        }

        // Perform raycast from the camera's viewpoint
        private void PerformRaycastFromCamera()
        {
            interactableObjectsInView.Clear();  // Clear previous raycast results

            // Raycast from the center of the camera's viewport
            Ray ray = fixedCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, interactableLayer);

            // Collect interactable objects hit by the raycast
            foreach (var hit in hits)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactableObjectsInView.Add(interactable);
                }
            }
        }

        // Method to get interactable objects within a certain range of any position (not just the player)
        public List<IInteractable> GetInteractablesWithinRange(Vector3 position, float range)
        {
            List<IInteractable> nearbyInteractables = new List<IInteractable>();

            foreach (var interactable in interactableObjectsInView)
            {
                // Assuming that the IInteractable is attached to a GameObject
                GameObject interactableObject = interactable as MonoBehaviour ? ((MonoBehaviour)interactable).gameObject : null;

                if (interactableObject != null)
                {
                    float distance = Vector3.Distance(interactableObject.transform.position, position);
                    if (distance <= range)
                    {
                        nearbyInteractables.Add(interactable);
                    }
                }
            }

            return nearbyInteractables;
        }
    }
}
