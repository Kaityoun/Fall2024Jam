using UnityEngine;

namespace ScaredyKat.Interactables
{
    public class TestInteractable : BaseInteractable
    {
        // Override the Interact method to provide the desired functionality
        public override void Interact()
        {
            base.Interact(); // Call the base method if you want to retain base functionality
            Debug.Log("TestInteractable has been interacted with!");
        }
    }
}

