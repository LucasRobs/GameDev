using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Odor : MonoBehaviour
{
    int damage = 1;

    public void init(int damage){
        this.damage = damage;
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == "Entity"){
            other.gameObject.GetComponent<Entity>().doDamage(damage);
        }
    }
}
