using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellThunderBall : MonoBehaviour
{

  public GameObject projectile;
  public int level = 1;
  public float mira = 0;

  float waitTime = 1f;
  float lifeBulletTime = 1f;

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
    projectileManager.init(level + baseDamage, level * baseDrilling);
    return projectile;
  }

  IEnumerator handleShoot(float waitTime, float lifeBulletTime)
  {
    yield return new WaitForSeconds(0.5f * waitTime);
    GameObject project = shoot();
    yield return new WaitForSeconds(waitTime);
    StartCoroutine(handleShoot(waitTime, lifeBulletTime));
    yield return new WaitForSeconds(lifeBulletTime - waitTime);
    if (project) Destroy(project);
  }
}
