using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
  private void Start(){
    StartCoroutine(destroyBlood());
  }
  IEnumerator destroyBlood()
  {
    yield return new WaitForSeconds(0.3f);
    Destroy(this.gameObject);
  }
}