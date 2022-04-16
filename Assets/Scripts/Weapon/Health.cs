using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class Health : MonoBehaviour
    {
        public int health = 100;
    
        public void Hit(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Die();
            }
           
        }
    
        private void Die()
        {
            Destroy(gameObject);
        }
    }
}

