using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingBox : MonoBehaviour
{
    [SerializeField] private float pushForce;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null)
        {
            Vector3 moveDir = hit.gameObject.transform.position - transform.position;
            moveDir.y = 0;
            moveDir.Normalize();
            
            rb.AddForceAtPosition(moveDir * pushForce, transform.position , ForceMode.Impulse);
        }
    }
}

