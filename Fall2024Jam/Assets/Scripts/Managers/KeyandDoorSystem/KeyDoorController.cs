using System.Collections;
using UnityEngine;
using ScaredyKat.Interactables;

namespace ScaredyKat.Managers.KeyandDoorSystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private bool doorOpen = false;

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;

        private void Awake()
        {
            // Removed Animator reference
        }

        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            Debug.Log("Pausing door interaction for " + waitTimer + " seconds.");
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
            Debug.Log("Door interaction resumed.");
        }

        public void PlayAnimation(Door door) // Accept a Door object
        {
            if (door is LockedDoor lockedDoor) // Check if it's a locked door
            {
                if (_keyInventory.hasRedKey)
                {
                    lockedDoor.Unlock(); // Unlock the door using the correct method
                    OpenDoor(); // Open the door
                }
                else
                {
                    StartCoroutine(ShowDoorLocked());
                }
            }
            else if (door is UnlockedDoor) // Check if it's an unlocked door
            {
                OpenDoor(); // Open the door
            }
            else if (door is BlockedDoor blockedDoor) // Check if it's a blocked door
            {
                blockedDoor.Unblock(); // Unblock the door first (if you have logic for this)
                OpenDoor(); // Then open the door
            }
        }

        void OpenDoor()
        {
            if (!doorOpen && !pauseInteraction)
            {
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
                Debug.Log("Door opened.");
            }
            else if (doorOpen && !pauseInteraction)
            {
                doorOpen = false;
                StartCoroutine(PauseDoorInteraction());
                Debug.Log("Door closed.");
            }
        }

        IEnumerator ShowDoorLocked()
        {
            Debug.Log("Attempting to show locked door UI.");
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorLockedUI.SetActive(false);
            Debug.Log("Locked door UI hidden after " + timeToShowUI + " seconds.");
        }
    }
}
