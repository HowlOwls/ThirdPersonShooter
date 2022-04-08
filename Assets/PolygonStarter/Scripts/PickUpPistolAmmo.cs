
using UnityEngine;

namespace Weapons
{
    public class PickUpPistolAmmo : MonoBehaviour
    {
        [SerializeField] private Pistol pistol;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                pistol.allAmmo += 15;
                Destroy(gameObject);
            }
        }
    }
}
