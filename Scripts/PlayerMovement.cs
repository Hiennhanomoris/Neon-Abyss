using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool facingRinght;
    private bool isOnGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float checkRadius;

    Rigidbody2D player_rb;

    private void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        facingRinght = true;

        PlayerStatus.Instance.setCurrentHealth(PlayerStatus.Instance.getMaxHealth());
        PlayerStatus.Instance.setCurrentJump(PlayerStatus.Instance.getExtraJump());
    }

    private void FixedUpdate()
    {
        HandleMovement();
        CheckOnGround();
    }

    private void Update()
    {
        HandleJumping();
    }

    private void HandleJumping()
    {
        if (isOnGround == true)
        {
            //reset current jump when player stand on the ground
            PlayerStatus.Instance.setCurrentJump(PlayerStatus.Instance.getExtraJump());
        }

        //player jumping when press key
        if (Input.GetKeyDown(KeyCode.Space) && PlayerStatus.Instance.getCurrentJump() > 0)
        {
            player_rb.velocity = Vector2.up * PlayerStatus.Instance.getJumpForce();
            PlayerStatus.Instance.setCurrentJump(PlayerStatus.Instance.getCurrentJump() - 1);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && PlayerStatus.Instance.getCurrentJump() > 0 && isOnGround)
        {
            player_rb.velocity = Vector2.up * PlayerStatus.Instance.getJumpForce();
        }
    }

    private void CheckOnGround()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    private void HandleMovement()
    {
        //move player 
        float horizontal = Input.GetAxis("Horizontal");
        player_rb.velocity = new Vector2(horizontal * PlayerStatus.Instance.getMoveSpeed(), player_rb.velocity.y);

        if ((facingRinght == false && horizontal > 0) || (facingRinght == true && horizontal < 0))
        {
            Flip();
        }
    }

    private void Flip()
    {
        //change direction of this object
        facingRinght = !facingRinght;
        Vector3 scaler = this.transform.localScale;
        scaler.x *= -1;
        this.transform.localScale = scaler;
    }
}
