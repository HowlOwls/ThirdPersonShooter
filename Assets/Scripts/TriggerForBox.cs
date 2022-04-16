using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForBox : MonoBehaviour
{
    [SerializeField] private Animator anim;
    
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("TriggerBox"))
        {
            anim.SetTrigger("Trigger");
            
        }
    }
}
