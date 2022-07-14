using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
  int value = 1;
  SpriteRenderer spriteRender;
  Controller controller;

  private void Start() {
    GameObject camera = GameObject.Find("Camera");
    controller = camera.GetComponent<Controller>();
    spriteRender = GetComponent<SpriteRenderer>();
    StartCoroutine(handleDestroy());
  }

  public void init(int index){
    this.transform.rotation = Quaternion.Euler(0, 0, -90);
    value = index;
  }

  void OnTriggerStay2D(Collider2D other){
      if (other.gameObject.tag == "Coletor"){
          controller.takeSoul(value);
          Destroy(this.gameObject);
      }
  }

    IEnumerator handleDestroy()
    {  
        yield return new WaitForSeconds(5f);
        for(int i = 0; i < 200; i++){
          spriteRender.color = new Color(0, 0, 0, 0);
          yield return new WaitForSeconds(0.01f);
          spriteRender.color = new Color(1, 1, 1, 1);
          yield return new WaitForSeconds(0.01f);
        }
        Destroy(this.gameObject);
    }
}