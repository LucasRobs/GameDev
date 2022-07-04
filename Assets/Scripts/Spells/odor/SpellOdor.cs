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
    int baseDamage = 2;
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
        projectileManager.init(level + baseDamage);
        this.gameObject.SetActive(true);
        return;
    }
}
