
using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Weapon
{
    public class Pistol : MonoBehaviour
    {
        private Transform mainCam;
        [SerializeField] private float fireRate;
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bulletPrefab;
        private Transform bulletParent;
        public int curAmmo;
        public int allAmmo;
        public int fullAmmo = 45;
        public int damage = 100;
        private float force = 40f;
        private float nextFire = 0;

        private void Start()
        {
            mainCam = Camera.main.transform;
        }
        
        private void Update()
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire && curAmmo > 0)
            {
                Shoot();
            }
            Reload();
        }
        private void Shoot()
        {
            nextFire = Time.time + 1f / fireRate;
            RaycastHit hitInfo;
            if (Physics.Raycast(mainCam.position, mainCam.forward, out hitInfo, 100))
            {
                var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }
            curAmmo--;
            
        }
        private void Reload()
        {
            if (Input.GetKeyDown(KeyCode.R) && allAmmo > 0)
            {
                int reason = 15 - curAmmo;
                if (allAmmo >= reason)
                {
                    int result = allAmmo - reason;
                    allAmmo = result;
                    curAmmo = 15;
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
