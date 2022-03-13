using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LineRenderer laserRd;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float laserDistance;

    private void OnEnable() 
    {
        DisableLaser();   
    }

    private void Update() 
    {
        if(Input.GetButtonDown("Fire1"))
        {
            EnableLaser();
        }    

        if(Input.GetButton("Fire1"))
        {
            UpdateLaser();
        }

        if(Input.GetButtonUp("Fire1"))
        {
            DisableLaser();
        }
    }

    private void EnableLaser()
    {
        laserRd.enabled = true;
    }

    private void UpdateLaser()
    {
        laserRd.SetPosition(0, firePoint.position);

        // caculate laser distance
        Vector2 secondPos = CaculatePos();

        laserRd.SetPosition(1, secondPos);
    }

    private Vector2 CaculatePos()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        float distance1 = Vector2.Distance(firePoint.position, mousePos);
        Vector2 temp = Vector2.zero;
        temp.x = (laserDistance/distance1)*(mousePos.x - firePoint.position.x) + firePoint.position.x;
        temp.y = (laserDistance/distance1)*(mousePos.y - firePoint.position.y) + firePoint.position.y;

        return temp;
    }

    private void DisableLaser()
    {
        laserRd.enabled = false;
    }


}
