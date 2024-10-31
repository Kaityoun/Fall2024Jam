
using UnityEngine;

namespace ScaredyKat.Interactables
{
    public class DoorInteractable : BaseInteractable
    {
        public override void Interact()
        {
            base.Interact(); // Optional: Call the base Interact method
            Debug.Log("Door has been interacted with!");
        }
    }
}

