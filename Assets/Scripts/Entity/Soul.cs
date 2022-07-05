using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
  int value = 1;
  Controller controller;

  private void Start() {
    controller = GameObject.Find("Camera").GetComponent<Controller>();
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
}