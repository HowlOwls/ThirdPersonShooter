
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;


namespace Controllers
{
    public class ZoomThenAim : MonoBehaviour 
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private CinemachineVirtualCamera zoomCamera;
        private InputAction aimAction;
        [SerializeField] private int priorityBoostAmount = 10;
        [SerializeField] private Canvas zoomCanvas;
        private void Awake()
        {
            aimAction = playerInput.actions["Aim"];
            zoomCamera = GetComponent<CinemachineVirtualCamera>();
        }

        private void OnEnable()
        {
            aimAction.performed += _ => StartAim();
            aimAction.canceled += _ => CancelAim();
        }

        private void OnDisable()
        {
            aimAction.performed -= _ => StartAim();
            aimAction.canceled -= _ => CancelAim();
        }

        private void StartAim()
        {
            zoomCamera.Priority += priorityBoostAmount;
            zoomCanvas.enabled = true;
        }

        private void CancelAim()
        {
            zoomCamera.Priority -= priorityBoostAmount;
            zoomCanvas.enabled = true;
        }

    }
}
 
