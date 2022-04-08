using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private float moveSpeed = 3;
   private Vector3 dir;
   private float hzInput, vInput;
   [SerializeField] private CharacterController controller;
   [SerializeField] private float groundYOffset;
   [SerializeField] private LayerMask groundMask;
   [SerializeField] private float gravity = -9.81f;
   private Vector3 velocity;
   private Vector3 spherePos;
   private void Start()
   {
      controller = GetComponent<CharacterController>();
   }

   private void Update()
   {
      GetDirAndMove();
      Gravity();
   }

   private void GetDirAndMove()
   {
      hzInput = Input.GetAxis("Horizontal");
      vInput = Input.GetAxis("Vertical");
      dir = transform.forward * vInput + transform.right * hzInput;
      controller.Move(dir.normalized * moveSpeed * Time.deltaTime);
   }

   private bool IsGrounded()
   {
      spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
      if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask));
      return false;
   }

   private void Gravity()
   {
      if (!IsGrounded())
         velocity.y += gravity * Time.deltaTime;
      else if (velocity.y < 0)
         velocity.y = -2f;

      controller.Move(velocity * Time.deltaTime);
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.red;
      Gizmos.DrawSphere(spherePos, controller.radius - 0.05f);
   }
}
