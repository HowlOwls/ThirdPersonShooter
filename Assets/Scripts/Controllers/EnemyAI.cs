
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Controllers
{
        public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform player;
        [SerializeField] private LayerMask groundLayer, playerLayer;
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform spawnPoint;
        
        [SerializeField] private Transform[] waypoints;
        private int mCurrentWayPoint;
        
        public float dist;
        [SerializeField] private float sightRange = 10;
        [SerializeField] private float attackRange = 5;
        
        [SerializeField] private bool playerInSightRange, playerInAttackRange;
        [SerializeField] private bool alreadyAttack;

        private float timeBtwAttack = 5f;
        private Rigidbody rb;
        private void Awake()
        {
            player = GameObject.Find("Player").transform;
            agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            agent.SetDestination(waypoints[0].position);
        }

        private void Update()
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
           
            dist = Vector3.Distance(player.transform.position, transform.position);

            if (!playerInSightRange && !playerInAttackRange)
            {
                if (agent.remainingDistance < agent.stoppingDistance)
                {
                    mCurrentWayPoint = (mCurrentWayPoint + 1) % waypoints.Length;
                    agent.SetDestination(waypoints[mCurrentWayPoint].position);
                }
            }

            if (playerInSightRange && !playerInAttackRange) // Если в радиусе обнаружения идет преследует игрока
            {
                
                agent.SetDestination(player.transform.position);
            }
            
            if (playerInSightRange && playerInAttackRange) // если в радиусе обнаружения и атаки, атакует
            {
                AttackPlayer();
            }
        }
        
        private void AttackPlayer()
        {
            agent.SetDestination(transform.position);
            transform.LookAt(player);
            if (!alreadyAttack)
            {
                Rigidbody rb = Instantiate(bullet, spawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(player.transform.position * 1f, ForceMode.Impulse);
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
