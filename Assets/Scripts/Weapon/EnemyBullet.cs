
using UnityEngine;

namespace Weapon

{
    public class EnemyBullet : MonoBehaviour
    {
        private void Awake()
        {
            Destroy(gameObject,2f);
        }
        
    }
}
