
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
   [RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
   public class PlayerController : MonoBehaviour
   {
      [SerializeField] private CharacterController controller;
      [SerializeField] private PlayerInput playerInput;
      [SerializeField] private Animator animator;
      private Transform cameraTransform;
      private Vector3 playerVelocity;
      
      [SerializeField] private Transform groundedCheck;
      [SerializeField] private LayerMask groundMask;
      private bool isGrounded;
      private float groundDist = 0.4f;
      
      
      [SerializeField] private float playerSpeed = 2.0f;
      [SerializeField] private float jumpHeight = 1.0f;
      [SerializeField] private float gravityValue = -9.81f;
      private int jumpAnimation;
      
      
      private int hzInputAnimationParameterId;
      private int vInputAnimationParameterId;
      private float animationPlayTransition = 0.15f;

      private InputAction moveAction;
      private InputAction jumpAction;
      
      private void Start()
      {
         moveAction = playerInput.actions["Move"];
         jumpAction = playerInput.actions["Jump"];
         hzInputAnimationParameterId = Animator.StringToHash("MoveX");
         vInputAnimationParameterId = Animator.StringToHash("MoveZ");
         jumpAnimation = Animator.StringToHash("Jump");
         controller = GetComponent<CharacterController>();
         playerInput = GetComponent<PlayerInput>();
         cameraTransform = Camera.main.transform;
      }
      
      void Update()
      {
         GetDirAndMove();
         Jump();
      }
      private void GetDirAndMove()
      {
         Vector2 input = moveAction.ReadValue<Vector2>();
         Vector3 move = new Vector3(input.x, 0, input.y);
         move = cameraTransform.right.normalized * move.x + cameraTransform.forward.normalized * move.z;
         move.y = 0f;
         controller.Move(move.normalized * Time.deltaTime * playerSpeed);
         
         //Вызываем анимацию ходьбы
         animator.SetFloat(hzInputAnimationParameterId, input.x);
         animator.SetFloat(vInputAnimationParameterId, input.y);
         
      }

      private void Jump()
      {
         isGrounded = Physics.CheckSphere(groundedCheck.position, groundDist, groundMask);
         if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
         
         if (jumpAction.triggered && isGrounded)
         {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2f * gravityValue);
            animator.CrossFade(jumpAnimation, animationPlayTransition);
         }
         playerVelocity.y += gravityValue * Time.deltaTime;
         controller.Move(playerVelocity * Time.deltaTime);
      }
   }
}
