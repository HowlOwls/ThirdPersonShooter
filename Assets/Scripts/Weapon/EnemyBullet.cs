
using System;
using UnityEngine;

namespace Weapon

{
    public class EnemyBullet : MonoBehaviour
    {
        private int damage = 20;
        private void Awake()
        {
            Destroy(gameObject,2f);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<Health>().Hit(damage);
                Destroy(gameObject);
            }
        }
    }
}
