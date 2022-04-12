
using UnityEngine;

namespace Weapons
{
    public class PickUpPistolAmmo : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                
                Destroy(gameObject);
            }
        }
    }
}
