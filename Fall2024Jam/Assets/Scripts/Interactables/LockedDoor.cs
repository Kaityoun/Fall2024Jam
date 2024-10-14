using UnityEngine;

namespace ScaredyKat.Interactables
{
    public class LockedDoor : Door
    {
        public string keyName; // The name of the key required to unlock the door
        private bool isUnlocked = false;

        public override void Interact()
        {
            if (isUnlocked)
            {
                Debug.Log("Door unlocked!");
                // Logic for opening the door
            }
            else
            {
                Debug.Log("Locked door, need key!");
            }
        }

        public void Unlock()
        {
            isUnlocked = true;
            Debug.Log("Door is now unlocked.");
        }
    }
}
