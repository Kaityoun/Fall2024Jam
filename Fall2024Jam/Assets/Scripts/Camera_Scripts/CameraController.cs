using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using ScaredyKat.Player;
using ScaredyKat.Interactables;

namespace ScaredyKat.Camera_Scripts
{
    public class CameraController : MonoBehaviour
    {
        public CinemachineVirtualCamera triggerCamera; // Add this back to the class
        public Transform Player; // Reference to the Player object
        public LayerMask interactableLayer;  // Layer mask to filter interactable objects
        private static CinemachineVirtualCamera activeCam; // Currently active camera

        // Store interactable objects detected by the camera
        private List<IInteractable> interactableObjectsInView = new List<IInteractable>();

        private void Start()
        {
            // Find all CinemachineVirtualCamera instances in the scene
            CinemachineVirtualCamera[] allCameras = Object.FindObjectsByType<CinemachineVirtualCamera>(FindObjectsSortMode.None);
            
            foreach (var cam in allCameras)
            {
                PerformRaycastFromCamera(cam);
            }

            // Set the first camera as the active camera by default (optional)
            if (allCameras.Length > 0)
            {
                activeCam = allCameras[0]; // You can choose the desired camera based on your logic
                activeCam.Priority = 1; // Set default camera active
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log($"Player entered {gameObject.name}. Activating camera: {triggerCamera.name}");

                if (activeCam != triggerCamera)
                {
                    SetActiveCamera(triggerCamera);
                    GivePlayerInteractables(other.GetComponent<PlayerController>());
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log($"Player exited {gameObject.name}. Last active camera remains: {activeCam.name}");
                // No action is taken here; the last camera stays active.
            }
        }

        private void SetActiveCamera(CinemachineVirtualCamera newCam)
        {
            // Deactivate the previous active camera
            if (activeCam != null)
            {
                activeCam.Priority = 0; // Deactivate current camera
            }

            // Activate the new camera if it's not null
            if (newCam != null)
            {
                activeCam = newCam;
                activeCam.Priority = 1; // Set new camera active
                PerformRaycastFromCamera(newCam); // Perform raycast when changing camera
            }
        }

        // Perform raycast from the specified camera's viewpoint
        private void PerformRaycastFromCamera(CinemachineVirtualCamera camera)
        {
            interactableObjectsInView.Clear();  // Clear previous results
            Debug.Log($"Performing raycast from camera: {camera.name}");

            // Access the main camera's Transform to perform the raycast
            Camera mainCamera = Camera.main;
            if (mainCamera == null)
            {
                Debug.LogWarning("No main camera found in the scene.");
                return; // Exit if there's no main camera
            }

            // Raycast from the center of the camera's viewport
            Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, interactableLayer);

            // Log the number of hits detected
            Debug.Log($"Raycast detected {hits.Length} objects from camera: {camera.name}");

            // Collect interactable objects hit by the raycast
            foreach (var hit in hits)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactableObjectsInView.Add(interactable);
                    Debug.Log($"Detected interactable object: {hit.collider.name} at position: {hit.collider.transform.position}");
                }
            }
        }

        private void GivePlayerInteractables(PlayerController playerController)
        {
            playerController.setInteractables(interactableObjectsInView);
            Debug.Log($"Gave player {interactableObjectsInView.Count} interactable(s).");
        }
    }
}
