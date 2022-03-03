using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingGround : MonoBehaviour
{
    private PlatformEffector2D effector;
    private GameObject player;
    [SerializeField] private float force;

    private void Start() 
    {
        effector = GetComponent<PlatformEffector2D>();  
        player = GameObject.FindGameObjectWithTag("Player");  
    }

    private void Update() 
    {
        //rotate this when press S for 0.5s
        if(Input.GetKey(KeyCode.S))
            effector.rotationalOffset = 180f; 
        //reset rotation
        else
        {
            if(player.GetComponent<PlayerMovement>().GetIsOnJumpingGround())
                {
                    player.GetComponent<Rigidbody2D>().velocity = Vector2.up * force;
                }
            effector.rotationalOffset = 0f; 
        }
    }
}
