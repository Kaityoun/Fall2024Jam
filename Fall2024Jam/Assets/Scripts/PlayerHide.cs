using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    public GameObject hideText, stopHideText;
    public GameObject normalPlayer, hidingPlayer;
    public enemyAI monsterScript; 
    public interactable hiding;
    public float loseDistance;

    // Start is called before the first frame update
    void Start()
    {
        interactable = false;
        hiding = false;
    }

    void OnTriggerStay(Collider other){
        if (other.CompareTag("MainCamera"))
        {
            hideText.SetActive(true);
            interactable(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            hideText.SetActive(false);
            interatable = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                hidingText.SetActive(false);
                hidingPlayer.SetActive(true);
                float distance = Vector3.Distance(monsterTransform, normalPlayer.transformposition);
                if(distance > loseDistance)
                {
                    if(monsterScript.chasing== true)
                    {
                        monsterScript.stopChase();
                    }
                }
            }
        }
    }
}
