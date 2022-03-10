using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyAbstract
{
    private float distance;
    [SerializeField] private GameObject enemy2Bullet;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float bulletSpeed;
    private bool ready2Fire;
    private bool facingRinght;

    public override void Start()
    {
        base.Start();
        ready2Fire = false;
        facingRinght = true;
        StartCoroutine(Fire());
        
    }
    private void Update() 
    {
        distance = Vector2.Distance(this.transform.position, PlayerStatus.Instance.transform.position);
        if(distance > moveDistance)
        {
            Move();
            ready2Fire = false;
        }
        else 
        {
            ready2Fire = true;
            Idle();
        }

        if((this.transform.position.x >= PlayerStatus.Instance.transform.position.x && facingRinght) || 
        (this.transform.position.x < PlayerStatus.Instance.transform.position.x && facingRinght == false))
        {
            Flip();
        }
    }

    private void Idle()
    {
        enemyRb.velocity = Vector2.zero;
    }

    private void Move()
    {
        Vector2 direct = PlayerStatus.Instance.transform.position - this.transform.position;
        enemyRb.velocity = direct.normalized * moveSpeed;
    }

    private IEnumerator Fire()
    {
        while(true)
        {
            if(ready2Fire)
            {
                Vector2 direct = PlayerStatus.Instance.transform.position - this.transform.position;
                GameObject bullet = Instantiate(enemy2Bullet, spawnPoint.position, Quaternion.identity);

                bullet.GetComponent<Rigidbody2D>().AddForce(direct.normalized * bulletSpeed, ForceMode2D.Impulse);
            }
            yield return new WaitForSeconds(2f);
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
