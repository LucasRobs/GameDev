using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBall : MonoBehaviour
{
  public int damage = 1;
  public int drilling = 9999;
  Vector3 proximo = new Vector3();

  void Start(){
    //Vector3 proximo = getProximity();
  }
  
  void Update(){}

  public void init(int damage, int drilling)
  {
    this.damage = damage;
    this.drilling = drilling;
  }

  private void FixedUpdate(){
    transform.Translate(new Vector2(proximo.x, proximo.y) * 3.5f * Time.deltaTime);
  }

  Vector3 getProximity(){
    GameObject[] entitys = GameObject.FindGameObjectsWithTag("Entity");
    float menor = Vector3.Distance(entitys[0].transform.position, this.transform.position);
    Vector3 positionMaisProximo = entitys[0].transform.position;
    foreach (GameObject entity in entitys){
      float maisProximo = Vector3.Distance(entity.transform.position, this.transform.position);
      if (maisProximo < menor){
        menor = maisProximo;
        positionMaisProximo = entity.transform.position;
      }
    }
    return positionMaisProximo;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Entity"){
      other.gameObject.GetComponent<Entity>().doDamage(damage);
    }
  }
  void handleDrilling(){
     if (drilling <= 999){
        drilling--;
        if (drilling <= 0){
          Destroy(transform.gameObject);
        }
      }
  }
}
