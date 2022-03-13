using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotting : MonoBehaviour
{
    [SerializeField] private float bulletForce;
    [SerializeField] private Camera cam;
    [SerializeField] GameObject playerBullet;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private GunSO gunStatus;
    private Rigidbody2D gunRb;

    private void OnEnable() 
    {
        gunRb = GetComponent<Rigidbody2D>();
        StartCoroutine(Shotting());
    }

    private IEnumerator Shotting()
    {
        while(PlayerStatus.Instance.getCurrentHealth() > 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = mousePos - new Vector2(this.transform.position.x, this.transform.position.y);

                GameObject bullet = Instantiate(playerBullet, spawnPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);

                yield return new WaitForSeconds(gunStatus.fireRate);
            }
            else yield return null;
        }
    }
}
