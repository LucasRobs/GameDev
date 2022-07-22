using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
  int value = 20;
  SpriteRenderer spriteRender;
  Controller controller;

  private void Start() {
    GameObject camera = GameObject.Find("Camera");
    controller = camera.GetComponent<Controller>();
    spriteRender = GetComponent<SpriteRenderer>();
    value += Random.Range(0, controller.getLevel());
    StartCoroutine(handleDestroy());
  }

  void OnTriggerStay2D(Collider2D other){
      if (other.gameObject.tag == "Coletor"){
          controller.takeFood(value);
          Destroy(this.gameObject);
      }
  }

    IEnumerator handleDestroy()
    {  
        yield return new WaitForSeconds(60f);
        for(int i = 0; i < 200; i++){
          spriteRender.color = new Color(0, 0, 0, 0);
          yield return new WaitForSeconds(0.01f);
          spriteRender.color = new Color(1, 1, 1, 1);
          yield return new WaitForSeconds(0.01f);
        }
        Destroy(this.gameObject);
    }
}