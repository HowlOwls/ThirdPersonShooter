using System;
using UnityEngine;

namespace  Weapon
{
    public class LandMine : MonoBehaviour
    {
        
        private float radius = 10;
        [SerializeField] private int damage;
        [SerializeField] private float force;
        

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
                foreach (var nearbyObject in colliders)
                {
                    Health health = nearbyObject.GetComponent<Health>();
                    if(health != null)
                        health.Hit(damage);
                    
                    if (nearbyObject.GetComponent<Rigidbody>())
                    {
                        nearbyObject.GetComponent<Rigidbody>().AddForce( transform.forward * force);
                    }
                }
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
