using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellOdor : MonoBehaviour, ISpellControler
{
    public GameObject odor;
    GameObject player;
    PlayerControler playerControler;
    float waitTime = 5f;
    float lifeBulletTime = 2f;
    int baseDamage = 1;
    int damage = 0;
    int baseDrilling = 2;
    int level = 0;
    GameObject projectile;
    Odor projectileManager;
    
    void Awake(){
        player = GameObject.Find("Player");
        playerControler = player.GetComponent<PlayerControler>();
        projectile = Instantiate(this.odor, transform.position, Quaternion.Euler(0, 0, 0));
        projectile.transform.SetParent(transform);
        projectileManager = projectile.GetComponent<Odor>();
        init();
    }

    void init(){
        StartCoroutine(handleShoot());
    }

    IEnumerator handleShoot(){
        projectileManager.init(damage);
        projectile.SetActive(true);
        if(waitTime - lifeBulletTime > 0){
            yield return new WaitForSeconds(lifeBulletTime);
            projectile.SetActive(false);
            yield return new WaitForSeconds(waitTime - lifeBulletTime);
            StartCoroutine(handleShoot());
        }
    }

    public void addSkill(){
        //if(!projectileManager){init();}
        level += 1;
        if(level % 2 != 0){
            this.transform.localScale = new Vector3(
                this.transform.localScale.x * 1.1f, 
                this.transform.localScale.y * 1.1f, 
                1);
        }else{
            damage += (level/2) + 1;
        }
        this.gameObject.SetActive(true);
        return;
    }
}
