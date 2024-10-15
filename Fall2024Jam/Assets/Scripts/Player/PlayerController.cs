using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScaredyKat.Camera_Scripts;
using ScaredyKat.Interactables;

namespace ScaredyKat.Player
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterController controller;
        public float speed = 5f;
        public float turnSpeed = 180f;

        // The radius within which to check for interactable objects
        public float interactionRadius = 3f; 
        // Time between checks
        public float checkInterval = 0.5f; // Check every half second

        private List<IInteractable> interactableObjectsInView = new List<IInteractable>();

        // Start is called before the first frame update
        void Start()
        {
            controller = GetComponent<CharacterController>();
            // Start checking for interactables
            InvokeRepeating(nameof(CheckForInteractables), 0f, checkInterval);
        }

        // Update is called once per frame
        void Update()
        {
            HandleMovement(); // Handle player movement
            HandleInteraction(); // Handle player interaction
        }

        // Method to handle player movement
        private void HandleMovement()
        {
            // Get input for movement and rotation
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Rotate the player based on horizontal input
            transform.Rotate(0, horizontalInput * turnSpeed * Time.deltaTime, 0);

            // Calculate movement direction
            Vector3 movDir = transform.forward * verticalInput * speed;

            // Move the player
            controller.Move(movDir * Time.deltaTime - Vector3.up * 0.1f);
        }

        // Method to find nearby interactable objects
        private void CheckForInteractables()
        {
            // Clear the current list of interactables
            interactableObjectsInView.Clear();

            // Find all colliders within the interaction radius
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRadius);
            foreach (var hitCollider in hitColliders)
            {
                // Check if the collider has an IInteractable component
                IInteractable interactable = hitCollider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    // Add the interactable object to the list
                    interactableObjectsInView.Add(interactable);
                }
            }

            // Update the interactable objects in view for any other systems (like the interaction manager)
            setInteractables(interactableObjectsInView);
        }

        // Method to handle player interaction
        private void HandleInteraction()
        {
            if (Input.GetKeyDown(KeyCode.E) && interactableObjectsInView.Count > 0)
            {
                // Call the Interact method on the first interactable object
                interactableObjectsInView[0].Interact();
            }
        }

        public void setInteractables(List<IInteractable> objects)
        {
            interactableObjectsInView = objects;
        }
    }
}
