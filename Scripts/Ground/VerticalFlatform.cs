using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalFlatform : MonoBehaviour
{
    private PlatformEffector2D effector;

    private void Start() 
    {
        effector = GetComponent<PlatformEffector2D>();    
    }

    private void Update() 
    {
        //rotate this when press S for 0.5s
        if(Input.GetKey(KeyCode.S))
            effector.rotationalOffset = 180f; 
        //reset rotation
        else
            effector.rotationalOffset = 0f; 
    }
}
