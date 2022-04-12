
using UnityEngine;

namespace Weapon

{
    public class EnemyBullet : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;

        private void Awake()
        {
            Destroy(gameObject,2f);
        }

        private void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
