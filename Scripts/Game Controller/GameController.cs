using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform enemy1SpawnPoint;
    [SerializeField] private GameObject hidenGround;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    private bool isHiden;

    private void Start() 
    {
        Instantiate(enemy1, enemy1SpawnPoint.position, Quaternion.identity);   
        StartCoroutine(SpawnEnemy2()); 
        isHiden = false;
        StartCoroutine(Hide());
    }

    private IEnumerator SpawnEnemy2()
    {
        while(PlayerStatus.Instance.getCurrentHealth() > 0)
        {
            for(int i = 0; i < 3; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-9f, 9f), 9f, 0f);
                Instantiate(enemy2, spawnPos, Quaternion.identity);
                
                yield return new WaitForSeconds(3f);
            }

            yield return new WaitForSeconds(15f);
        }
    }

    private IEnumerator Hide()
    {
        while(true)
        {
            hidenGround.SetActive(!isHiden);
            isHiden = !isHiden;

            yield return new WaitForSeconds(2f);
        }
    }
}
