
using UnityEngine;

namespace Weapon
{
    public class PickUpPistolAmmo : MonoBehaviour
    {
        [SerializeField] private Pistol pistol;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                pistol.allAmmo += 30;
                Destroy(gameObject);
            }
        }
    }
}
