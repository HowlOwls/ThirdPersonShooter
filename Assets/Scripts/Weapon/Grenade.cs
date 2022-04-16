
using UnityEngine;

namespace Weapon
{
    public class Grenade : MonoBehaviour
    {
        [SerializeField] private float radius;
        public int damage;
        [SerializeField] private GameObject explEffect;
        [SerializeField] private int curGrenade;
        [SerializeField] private float delay = 3f;
        private float countdown;
        private bool hasExploded = false;
        public float explosionForce = 10f;
        public float explosionRange = 20f;
        private void Start()
        {
            countdown = delay;
        }
        private void Update()
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0f && !hasExploded && curGrenade > 0)
            {
                Explode();
                hasExploded = true;
                curGrenade--;
            }
        }
        private void Explode()
        {
            var explosion = Instantiate(explEffect, transform.position, transform.rotation);
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider nearbyObject in colliders)
            {
                Health health = nearbyObject.GetComponent<Health>();
                if(health != null)
                    health.Hit(damage);

                if (nearbyObject.GetComponent<Rigidbody>())
                {
                    nearbyObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce,transform.position,explosionRange);
                }
            }
            Destroy(gameObject);
            Destroy(explosion,1f);
        }
    }
}
