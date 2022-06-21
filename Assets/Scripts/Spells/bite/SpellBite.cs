using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBite : MonoBehaviour
{
    public GameObject bite;
    GameObject player;
    PlayerControler playerControler;
    float waitTime = 1f;
    float lifeBulletTime = 0.5f;
    int baseDamage = 1;
    int baseDrilling = 2;
    int level = 1;

    void Start(){
        player = GameObject.Find("Player");
        playerControler = player.GetComponent<PlayerControler>();
        StartCoroutine(handleShoot(waitTime , lifeBulletTime));
    }

    public GameObject shoot(){
        Vector3 pos = transform.position;
        Vector2 direction = playerControler.getLookingFor();

        GameObject projectile = Instantiate(this.bite, new Vector3(pos.x+direction.x,pos.y+direction.y,0), Quaternion.Euler(0, 0, 0));
        projectile.transform.SetParent(transform);
        Bite projectileManager = projectile.GetComponent<Bite>();
        projectileManager.init(level + baseDamage);
        return projectile;
    }

    IEnumerator handleShoot(float waitTime, float lifeBulletTime){
        GameObject project = shoot();
        yield return new WaitForSeconds(lifeBulletTime);
        if (project) Destroy(project);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(handleShoot(waitTime, lifeBulletTime));
    }
}
