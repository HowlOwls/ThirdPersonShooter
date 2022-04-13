
using UnityEngine;

namespace Weapon
{
    public class TurretEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private LayerMask playerLayer;
       [SerializeField] private Transform target;
       private float turnSpeed = 1;
       [SerializeField] private float sightRange = 15f;
       [SerializeField] private float attackRange = 10f;
       
       [SerializeField] private bool playerInSightRange;
       [SerializeField] private bool playerInAttackRange;
       [SerializeField] private bool alreadyAttack;
       [SerializeField] private float timeBtwAttack = 2f;
       
       private void Awake()
       {
           target = GameObject.Find("LookAt").transform;
       }
    
       private void Update()
       { 
           playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
          playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
          
          Vector3 targetDir = target.position - transform.position;
          float singleStep = turnSpeed * Time.deltaTime;
          Vector3 newDirect = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0f);
          
          if (playerInSightRange && !playerInAttackRange)
          {
              transform.rotation = Quaternion.LookRotation(newDirect);
          }
          
          if (playerInSightRange && playerInAttackRange)
          {
              transform.rotation = Quaternion.LookRotation(newDirect);
              Attack();
          }
       }
       private void Attack()
       {
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
