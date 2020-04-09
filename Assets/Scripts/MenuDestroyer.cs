using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoDestroy());
    }
    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}