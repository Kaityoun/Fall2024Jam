using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace ScardeyKat.Camera_Scripts
{
    public class CameraController : MonoBehaviour
    {
        public Transform Player; // Reference to the Player object
        public CinemachineVirtualCamera triggerCamera; // Camera associated with this trigger
        private static CinemachineVirtualCamera activeCam; // Currently active camera

        private void Start()
        {
            // Set the first camera as the active camera by default (optional)
            if (triggerCamera != null)
            {
                activeCam = triggerCamera;
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
            }
        }
    }


}
