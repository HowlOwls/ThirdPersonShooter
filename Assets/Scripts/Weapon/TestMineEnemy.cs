
using UnityEngine;

namespace Controllers
{
    public class TestMineEnemy : MonoBehaviour
    {
        private void Update()
        {
            transform.position += Vector3.forward * Time.deltaTime;
        }
    }
}
