using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable2 : MonoBehaviour
{
    public enum InteractionType{
        Click,
        Hold,
        Minigame
    }

    public interactionType interactionType;
    public abstract string GetDescription();
    public abstract void Interact();
    

}
