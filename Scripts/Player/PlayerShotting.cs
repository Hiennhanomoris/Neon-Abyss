using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotting : MonoBehaviour
{
    [SerializeField] private float bulletForce;
    [SerializeField] private Camera cam;
    [SerializeField] GameObject playerBullet;
    [SerializeField] Transform spawnPoint;
    private Rigidbody2D playerRb;

    private void Start() 
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        Shotting();
    }

    private void Shotting()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePos - new Vector2(this.transform.position.x, this.transform.position.y);

            GameObject bullet = Instantiate(playerBullet, spawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);
        }
    }
}
