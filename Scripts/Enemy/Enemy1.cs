using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyAbstract
{
    private bool isMovingRight;
    private RaycastHit2D groundInfor;
    [SerializeField] Transform groundDetection;

    public override void Start()
    {
        base.Start();
        isMovingRight = true;
    }

    private void Update() 
    {
        this.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        groundInfor = Physics2D.Raycast(groundDetection.position, Vector2.down, moveDistance);
        if(groundInfor.collider == false)
        {
            if(isMovingRight == true)
            {
                transform.eulerAngles = new Vector3(0f, -180f, 0f);
                isMovingRight = false;
            }
            else 
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isMovingRight = true;
            }
        }
    }
}
