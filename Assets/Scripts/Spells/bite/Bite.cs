using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : MonoBehaviour
{
    int damage = 1;

    public void init(int damage){
        this.damage = damage;
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Entity"){
            other.gameObject.GetComponent<Entity>().doDamage(damage);
        }
    }
}
