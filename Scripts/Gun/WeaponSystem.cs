using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] GameObject[] listWeapon;

    private void Start() 
    {
        for(int i = 0; i < listWeapon.Length; i++)
        {
            listWeapon[i].SetActive(false);
        }    
    }
}
