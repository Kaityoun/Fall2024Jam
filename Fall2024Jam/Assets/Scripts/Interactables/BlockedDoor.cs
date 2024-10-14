using UnityEngine;

namespace ScaredyKat.Interactables
{
    public class BlockedDoor : Door
    {
        private bool isBlocked = true;

        public override void Interact()
        {
            if (isBlocked)
            {
                Debug.Log("Door is blocked!");
            }
            else
            {
                Debug.Log("Door opened!");
                // Logic for opening the door
            }
        }

        public void Unblock()
        {
            isBlocked = false;
            Debug.Log("Door is now unblocked.");
        }
    }
}
