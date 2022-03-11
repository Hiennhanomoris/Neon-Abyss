using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Bullet : MonoBehaviour
{
    private Rigidbody2D bulletRb;

    private void Start() 
    {
        bulletRb = GetComponent<Rigidbody2D>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(!other.CompareTag("Enemy") && !other.CompareTag("Map") && !other.CompareTag("Background"))
            Destroy(this.gameObject);    
    }
}
