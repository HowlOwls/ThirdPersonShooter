
using System;
using UnityEngine;


namespace Weapon
{
    public class Pistol : MonoBehaviour
    {
        [SerializeField] private float fireRate;
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Camera mainCamera;
        public int curAmmo;
        public int allAmmo;
        public int fullAmmo = 45;
        public int damage = 100;
        private float weaponRange = 50;
        private float force = 30f;
        private float nextFire = 0;

        private void Awake()
        {
            mainCamera = Camera.main;
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
            Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Vector3 targetPoint;
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, weaponRange))
            {
                targetPoint = hitInfo.point;
                var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = (targetPoint - transform.position).normalized * force;
                curAmmo--;
            }
            else
            {
                targetPoint = ray.GetPoint(75);
                var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = (targetPoint - transform.position).normalized * force;
                curAmmo--;
            }
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
