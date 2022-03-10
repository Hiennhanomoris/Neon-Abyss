using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D bounceRb;
    [SerializeField] private float bulletForce;
    private void Start() 
    {
        bounceRb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Map"))
        {
            var speed = bounceRb.velocity.magnitude;
            var direct = Vector3.Reflect(bounceRb.velocity.normalized, Vector3.up);

            bounceRb.velocity = direct * bulletForce;
        }        
    }
}
