using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellOrbe : MonoBehaviour, ISpellControler
{
    public GameObject orbe;
    public GameObject[] orbePoint;

    GameObject player;
    PlayerControler playerControler;
    float waitTime = 7f;
    float lifeBulletTime = 3f;
    int baseDamage = 1;
    int baseDrilling = 2;
    int level = 0;
    float rotation = 0f;
    int NOrbs = 0;
    int maxOrbs = 8;


    void Start(){
        player = GameObject.Find("Player");
        playerControler = player.GetComponent<PlayerControler>();
        StartCoroutine(handleShoot(waitTime , lifeBulletTime));
    }

    void FixedUpdate(){
        rotationSpawn();
    }

    void rotationSpawn(){
        rotation = rotation + Time.deltaTime * 100;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    public void shoot(float lifeBulletTime, GameObject point){
        GameObject projectile = Instantiate(this.orbe, point.transform.position, Quaternion.Euler(0, 0, 0));
        projectile.transform.SetParent(point.transform);
        Orbe projectileManager = projectile.GetComponent<Orbe>();
        projectileManager.init(level + baseDamage);
        StartCoroutine(handleShoot(projectile , lifeBulletTime));
    }

    IEnumerator handleShoot(float waitTime, float lifeBulletTime){
        for(int i = 0; i < NOrbs; i++){shoot(lifeBulletTime, orbePoint[i]);}
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(handleShoot(waitTime, lifeBulletTime));
    }
    IEnumerator handleShoot(GameObject project, float lifeBulletTime){
        yield return new WaitForSeconds(lifeBulletTime);
        if (project) Destroy(project);
    }

    public void addSkill(){
        level += 1;
        if(NOrbs < maxOrbs){
            NOrbs += 1;
        }
        this.gameObject.SetActive(true);
        return;
    }
}
