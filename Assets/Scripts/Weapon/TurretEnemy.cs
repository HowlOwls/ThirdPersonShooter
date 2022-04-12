using System;
using System.Collections;
using System.Collections.Generic;
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
       [SerializeField] private float dist;
       [SerializeField] private bool playerInSightRange;
       [SerializeField] private bool playerInAttackRange;
       [SerializeField] private bool alreadyAttack;
       [SerializeField] private float timeBtwAttack = 2f;
       
       private void Awake()
       {
           target = GameObject.Find("Player").transform;
       }
    
       private void Update()
       { 
           playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
          playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
          dist = Vector3.Distance(target.transform.position, transform.position);
          Vector3 targetDir = target.position - transform.position;
          float singleStep = turnSpeed * Time.deltaTime;
          
          
          if (playerInSightRange && !playerInAttackRange)
          {
              Vector3 newDirect = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0f);
              transform.rotation = Quaternion.LookRotation(newDirect);
          }
          
          
          
          if (playerInSightRange && playerInAttackRange)
          {
              Attack();
          }
       }
       private void Attack()
       {
           Vector3 targetDir = target.position - transform.position;
           float singleStep = turnSpeed * Time.deltaTime;
           Vector3 newDirect = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0f);
           transform.rotation = Quaternion.LookRotation(newDirect);
           
           if (!alreadyAttack)
           {
               var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
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
