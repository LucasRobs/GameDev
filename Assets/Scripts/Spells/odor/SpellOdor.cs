using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellOdor : MonoBehaviour, ISpellControler
{
    public GameObject odor;
    GameObject player;
    PlayerControler playerControler;
    float waitTime = 1f;
    float lifeBulletTime = 0.5f;
    int baseDamage = 1;
    int damage = 0;
    int baseDrilling = 2;
    int level = 0;
    GameObject projectile;
    public Odor projectileManager;
    
    void Awake(){
        player = GameObject.Find("Player");
        playerControler = player.GetComponent<PlayerControler>();
    }

    void init(){
        projectile = Instantiate(this.odor, transform.position, Quaternion.Euler(0, 0, 0));
        projectile.transform.SetParent(transform);
        projectileManager = projectile.GetComponent<Odor>();
        projectileManager.init(level + baseDamage);
    }

    public void addSkill(){
        if(!projectileManager){init();}
        level += 1;
        if(level % 2 != 0){
            this.transform.localScale = new Vector3(
                this.transform.localScale.x * 1.1f, 
                this.transform.localScale.y * 1.1f, 
                1);
        }else{
            damage += (level/2) + 1;
        }
        projectileManager.init(damage + baseDamage);
        this.gameObject.SetActive(true);
        return;
    }
}
