using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody rb;
        private float force = 20f;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            rb.AddForce(Vector3.forward * force * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
