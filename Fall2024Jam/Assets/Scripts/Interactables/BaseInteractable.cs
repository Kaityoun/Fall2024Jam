using UnityEngine;
using UnityEngine.Events;
using ScaredyKat.Player;

namespace ScaredyKat.Interactables
{
    [RequireComponent(typeof(Collider), typeof(Outline))]
    public abstract class BaseInteractable : MonoBehaviour, IInteractable
    {
        protected Outline outline;
        public string interactionMessage;
        public UnityEvent onInteraction;

        protected virtual void Awake()
        {
            outline = GetComponent<Outline>();
            if (outline == null)
            {
                Debug.LogError($"Outline component not found on {gameObject.name}.");
            }
        }

        protected virtual void Start()
        {
            if (outline != null)
            {
                outline.enabled = false;
            }
        }

        public virtual void Interact()
        {
            onInteraction?.Invoke();
            Debug.Log($"Interacted with {gameObject.name}");
        }

        public void EnableOutline()
        {
            if (outline != null)
            {
                outline.enabled = true;
            }
        }

        public void DisableOutline()
        {
            if (outline != null)
            {
                outline.enabled = false;
            }
        }

        public void ShowInteractionMessage()
        {
            HUDController.instance.EnableInteractionText(interactionMessage);
        }

        public void HideInteractionMessage()
        {
            HUDController.instance.DisableInteractionText();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerInteraction>()?.SetCurrentInteractable(this);
                EnableOutline();
                ShowInteractionMessage();
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerInteraction>()?.SetCurrentInteractable(null);
                DisableOutline();
                HideInteractionMessage();
            }
        }
    }
}

