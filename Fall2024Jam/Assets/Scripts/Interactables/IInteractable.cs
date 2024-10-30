using UnityEngine;

namespace ScaredyKat.Interactables
{
    public interface IInteractable
    {
        void Interact();         // Defines the main interaction action
        void EnableOutline();     // Enables visual feedback for interaction
        void DisableOutline();    // Disables visual feedback
        void ShowInteractionMessage(); // Show interaction prompt or message
        void HideInteractionMessage(); // Hide the prompt or message
    }
}
