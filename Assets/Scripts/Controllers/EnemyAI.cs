
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Controllers
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform target;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform spawnPoint;


        public float dist;
        [SerializeField] private float sightRange = 10;
        [SerializeField] private float attackRange = 5;

        [SerializeField] private bool playerInSightRange, playerInAttackRange;
        [SerializeField] private bool alreadyAttack;
        private float timeBtwAttack = 1f;

        private void Awake()
        {
            target = GameObject.Find("LookAt").transform;
            agent = GetComponent<NavMeshAgent>();
        }


        private void Update()
        {

            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

            dist = Vector3.Distance(target.transform.position, transform.position);

            if (!playerInSightRange && !playerInAttackRange)
            {
            }

            if (playerInSightRange && !playerInAttackRange) // Если в радиусе обнаружения идет преследует игрока
            {
                agent.SetDestination(target.transform.position);
            }

            if (playerInSightRange && playerInAttackRange) // если в радиусе обнаружения и атаки, атакует
            {
                AttackPlayer();
            }
        }
     
        private void AttackPlayer()
        {
            agent.SetDestination(transform.position);
            transform.LookAt(target);
            if (!alreadyAttack)
            {
                var bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().velocity = (target.position - transform.position).normalized * 10f;
                alreadyAttack = true;
                Invoke(nameof(ResetAttack), timeBtwAttack);

            }
        }
        
        private void ResetAttack()
        {
            alreadyAttack = false;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }
    }
    
    
}
