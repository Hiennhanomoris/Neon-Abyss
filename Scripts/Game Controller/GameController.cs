using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform enemy1SpawnPoint;
    [SerializeField] private GameObject enemy1;

    private void Start() 
    {
        Instantiate(enemy1, enemy1SpawnPoint.position, Quaternion.identity);    
    }
}
