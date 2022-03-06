using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidenGround : MonoBehaviour
{
    private bool isHiden;

    private void Start() 
    {
        isHiden = false;
        StartCoroutine(Hide());
    }

    private IEnumerator Hide()
    {
        while(true)
        {
            Debug.Log(isHiden);
            this.gameObject.SetActive(isHiden);
            isHiden = !isHiden;
            yield return new WaitForSeconds(2f);
        }
    }
}
