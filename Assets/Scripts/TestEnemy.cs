using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    
    
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime;
    }
}
