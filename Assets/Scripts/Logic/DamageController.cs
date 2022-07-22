using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(destroyDamege());
    }

    IEnumerator destroyDamege()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(this.gameObject);
    }
}
