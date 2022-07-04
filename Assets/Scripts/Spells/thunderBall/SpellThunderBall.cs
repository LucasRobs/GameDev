using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellThunderBall : MonoBehaviour, ISpellControler
{

  public GameObject projectile;
  public int level = 0;
  public float mira = 0;

  float waitTime = 1f;
  float lifeBulletTime = 3f;
  float nBullets = 1;
  int damage = 1;

  void Start()
  {
    StartCoroutine(handleShoot(waitTime , lifeBulletTime));
  }

  private void upLevel()
  {
    this.level++;
  }

  public GameObject shoot()
  {
    const int baseDamage = 1;
    const int baseDrilling = 2;
    mira = (mira + 8) % 360;
    GameObject projectile = Instantiate(this.projectile, transform.position, Quaternion.Euler(0, 0, mira));
    ThunderBall projectileManager = projectile.GetComponent<ThunderBall>();
    projectileManager.init(damage + baseDamage, (level/2) * baseDrilling);
    return projectile;
  }

  IEnumerator handleShoot(float waitTime, float lifeBulletTime)
  {
    yield return new WaitForSeconds(0.5f * waitTime);
    List<GameObject> projects = new List<GameObject>();
    for (int i = 0; i < nBullets; i++){projects.Add(shoot());}
    yield return new WaitForSeconds(waitTime);
    StartCoroutine(handleShoot(waitTime, lifeBulletTime));
    yield return new WaitForSeconds(lifeBulletTime - waitTime);
    for(int i = 0; i < projects.Count; i++){if (projects[i]) Destroy(projects[i]);}
  }

  public void addSkill(){
    level += 1;
    if(level % 2 != 0){
      nBullets += 1;
    }else{
      damage += (level/2) + 1;
    }

    this.gameObject.SetActive(true);
    return;
  }
}
