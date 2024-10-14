using UnityEngine;

namespace ScaredyKat.Interactables
{
    public abstract class Door : MonoBehaviour, IInteractable
    {
        public abstract void Interact();
    }
}
