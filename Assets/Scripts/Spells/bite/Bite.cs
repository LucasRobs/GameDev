using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : MonoBehaviour
{
    int damage = 1;
    Vector2 direccion = new Vector2(1,0);

    public void init(int damage){
        this.damage = damage;
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Entity"){
            other.gameObject.GetComponent<Entity>().doDamage(damage);
        }
    }
}
