using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScaredyKat.Managers.KeyandDoorSystem
{
    public class KeyItemController : MonoBehaviour
    {
       [SerializeField] private bool redDoor = false;
       [SerializeField] private bool redKey = false;

       [SerializeField] private KeyInventory _keyInventory = null;

       private KeyDoorController doorObject;

       private void Start()
       {
        if (redDoor)
        {
            doorObject = GetComponent<KeyDoorController>();
        }
       }

       public void ObjectInteraction()
       {
        if(redDoor)
        {
            Debug.Log("play animation");
        }
        else if (redKey)
        {
            _keyInventory.hasRedKey = true;
            gameObject.SetActive(false);
        }
        
       }
    }
}
