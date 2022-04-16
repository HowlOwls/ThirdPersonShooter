using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    private Animation anim;

    
    private void Update()
    {
        anim.GetComponent<Animation>();
        anim.Play("PlayFly");
    }
}
