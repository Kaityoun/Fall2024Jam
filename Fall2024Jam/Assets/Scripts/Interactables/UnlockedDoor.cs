using UnityEngine;

namespace ScaredyKat.Interactables
{
    public class UnlockedDoor : Door
    {
        public override void Interact()
        {
            Debug.Log("Door opened!");
            // Logic for opening the door(?)
        }
    }
}

