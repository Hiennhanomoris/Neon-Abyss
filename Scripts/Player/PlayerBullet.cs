using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D bulletRb;

    private void Start() 
    {
        bulletRb = GetComponent<Rigidbody2D>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(!other.CompareTag("Player") && !other.CompareTag("Map") && !other.CompareTag("Background") && !other.CompareTag("Player Bullet"))
            Destroy(this.gameObject);    
    }
}
