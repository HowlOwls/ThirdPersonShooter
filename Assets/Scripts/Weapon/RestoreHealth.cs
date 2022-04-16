using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

public class RestoreHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Health personalHealth = other.GetComponent<Health>();
        if (other.CompareTag("Player")&& personalHealth.health < 100)
        {
            personalHealth.health += 50;
            Destroy(gameObject);
        }
    }
}
