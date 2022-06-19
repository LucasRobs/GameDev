using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
  private GameObject player;
  private GameObject camera;

  public int vida;
  private Counter counter;
  private bool invulnerable;

  public float speed = 1f;
  private Transform positionPlayer;

  public int level = 1;

  private bool isBoss = false;
  private SpawPoint spawPoint;
  private void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    camera = GameObject.Find("Camera");
    counter = camera.GetComponent<Counter>();
    positionPlayer = player.transform;
  }

  private void Update()
  {
    if (positionPlayer.gameObject != null)
    {
      transform.position = Vector2.MoveTowards(transform.position, positionPlayer.position, speed * Time.deltaTime);
    }
  }

  public void setLevel(int level)
  {
    this.vida = level * 2;
    this.level = level;
  }

  public void setSpeed(float speed){
    this.speed = speed;
  }

  public void setIsBossToTrue(){
    print("asdasdasd");

    this.isBoss = true;
    print(isBoss+ "aaaaaaaaasdasdasd");

  }

  public void setSpawPoint(SpawPoint spawPoint){
    this.spawPoint = spawPoint;
  }

  public void doDamage(int damage)
  {
    if(invulnerable)return;
    StartCoroutine(handleIvunerable());
    vida -= damage;
    if (vida <= 0)
    {
      if(isBoss){
        spawPoint.setBossWaveToZero();
      }
      Destroy(transform.gameObject);
      counter.addKill(level*2);
    }
  }
  IEnumerator handleIvunerable()
    {  
        invulnerable = true;
        yield return new WaitForSeconds(0.5f);
        invulnerable = false;
    }
}