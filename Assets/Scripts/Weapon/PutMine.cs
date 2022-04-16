using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class PutMine : MonoBehaviour
    {
        [SerializeField] private GameObject minePrefab;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private float installationRange;
        
        private void Update()
        {
            Installation();
        }

        private void Installation()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, installationRange))
                {
                    Instantiate(minePrefab, hit.point, transform.rotation);
                }
            }
        }
    }
}
