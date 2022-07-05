using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBite : MonoBehaviour, ISpellControler
{
    public GameObject bite;
    GameObject player;
    PlayerControler playerControler;
    float waitTime = 1f;
    float lifeBulletTime = 0.5f;
    int baseDamage = 1;
    int baseDrilling = 2;
    int level = 1;
    int nBites = 2;
    
    void Awake(){
        player = GameObject.Find("Player");
        playerControler = player.GetComponent<PlayerControler>();
        StartCoroutine(handleShoot(waitTime , lifeBulletTime));
    }

    public void shoot(float lifeBulletTime , int index){
        Vector3 pos = transform.position;
        Vector2 direction = playerControler.getLookingFor();
        float rotation = 0;
    
        if(direction.x > 0){
            rotation = 270;
        }else if(direction.x < 0){
            rotation = 90;
        }else if(direction.y > 0){
            rotation = 0;
        }else{
            rotation = 180;
        }
        GameObject projectile = Instantiate(this.bite, new Vector3(
            pos.x+direction.x * (1+(index*0.3f)),
            pos.y+direction.y * (1+(index*0.3f)),
            0), 
            Quaternion.Euler(0, 0, rotation));
        projectile.transform.SetParent(transform);
        Bite projectileManager = projectile.GetComponent<Bite>();
        projectileManager.init(level + baseDamage);
        StartCoroutine(handleDestroy(projectile, lifeBulletTime));
    }

    IEnumerator handleDestroy(GameObject projectile, float lifeBulletTime){
        yield return new WaitForSeconds(lifeBulletTime);
        if (projectile) Destroy(projectile);
    }

    IEnumerator handleShoot(float waitTime, float lifeBulletTime){
        for(int i = 0; i < nBites;i++){ 
            yield return new WaitForSeconds(0.02f);
            shoot(lifeBulletTime,i);
    }
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(handleShoot(waitTime, lifeBulletTime));
    }

    public void addSkill(){
        level += 1;
        nBites += 1;
        this.gameObject.SetActive(true);
        return;
    }
}
