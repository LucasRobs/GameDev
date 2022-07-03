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

    void Start(){
        player = GameObject.Find("Player");
        playerControler = player.GetComponent<PlayerControler>();
        projectile = Instantiate(this.odor, transform.position, Quaternion.Euler(0, 0, 0));
        projectile.transform.SetParent(transform);
        Odor projectileManager = projectile.GetComponent<Odor>();
        projectileManager.init(level + baseDamage);
    }


    public void addSkill(){
        level += 1;
        this.gameObject.SetActive(true);
        return;
    }
}
