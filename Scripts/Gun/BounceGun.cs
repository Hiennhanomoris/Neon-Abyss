using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceGun : MonoBehaviour
{
    [SerializeField] private GunSO bounceStatus;

    private GameObject player;
    private GameObject weaponSystem;

    private void OnEnable() 
    {
        player = GameObject.Find("Player");
        weaponSystem = GameObject.Find("Weapon System");
    }

    private void Update() 
    {
        float distance = Vector2.Distance(this.transform.position, player.transform.position);   

        if(distance < 0.2f)
        {
            weaponSystem.GetComponent<WeaponSystem>().WeaponSwapping("Bounce Gun");
            this.gameObject.SetActive(false);
        } 
    }
}
