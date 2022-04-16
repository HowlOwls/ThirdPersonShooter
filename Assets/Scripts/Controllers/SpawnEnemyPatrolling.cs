
using UnityEngine;

namespace Controllers
{
    public class SpawnEnemyPatrolling : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Transform spawnPoint;
        private GameObject enemy;

        void Update()
        {
            EnemySpawn();
        }

        private void EnemySpawn()
        {
            if (enemy == null)
            {
                enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            
            }
        }
    }
}
