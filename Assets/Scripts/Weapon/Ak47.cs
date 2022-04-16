using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class Ak47 : MonoBehaviour
    {
        
        [SerializeField] private float range;
        [SerializeField] private float fireRate;
        public int curAmmo;
        public int allAmmo;
        public int fullAmmo = 450;
        public int damage = 100;
    
        private float nextFire = 0;
    
        private void Update()
        {
            Shoot();
            Reload();
        }
    
        private void Shoot()
        {
            if(Input.GetButton("Fire1") && Time.time > nextFire && curAmmo > 0)
            {
                nextFire = Time.time + 1f / fireRate;
               
                curAmmo--;
            }
        }
        
        private void Reload()
        {
            if (Input.GetKeyDown(KeyCode.R) && allAmmo > 0)
            {
                int reason = 45 - curAmmo;
                if (allAmmo >= reason)
                {
                    int result = allAmmo - reason;
                    allAmmo = result;
                    curAmmo = 45;
                }
                else
                {
                    curAmmo = curAmmo + allAmmo;
                    allAmmo = 0;
                }
            }
        }
    }
}
