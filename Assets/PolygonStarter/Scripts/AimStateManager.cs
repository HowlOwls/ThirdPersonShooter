using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AimStateManager : MonoBehaviour
{
    [SerializeField] private Transform camFollowPos;
    [SerializeField] private float xAxis, yAxis;
    private float mouseSens = 1;
    private void Update()
    {
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSens;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSens;
        yAxis = Mathf.Clamp(yAxis, -80, 80);
    }

    private void LateUpdate()
    {
        camFollowPos.localEulerAngles = new Vector3(yAxis, camFollowPos.localEulerAngles.y, camFollowPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
}
