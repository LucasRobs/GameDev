using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
  GameObject player;
  GameObject camera;

  public int vida;
  Counter counter;
  bool invulnerable;

  public float speed = 1f;
  Transform positionPlayer;

  public int level = 1;

  public  bool isBoss = false;
  SpawPoint spawPoint;
  SpriteRenderer spriteRender;
  
  private void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    camera = GameObject.Find("Camera");
    counter = camera.GetComponent<Counter>();
    spriteRender = GetComponent<SpriteRenderer>();
    positionPlayer = player.transform;
  }

  private void FixedUpdate()
  {
    if (positionPlayer.gameObject != null)
    {
      transform.position = Vector2.MoveTowards(transform.position, positionPlayer.position, speed * Time.deltaTime);
      handleFlip();
      handleLayer();
    }
  }

  private void handleFlip()
  {
    if (positionPlayer.position.x > transform.position.x) spriteRender.flipX = true;
    else spriteRender.flipX = false;
  }

  private void handleLayer()
  {
    spriteRender.sortingOrder = (int)(transform.position.y * -10);
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
    this.isBoss = true;
  }

  public void setSpawPoint(SpawPoint sp){
    this.spawPoint = sp;
  }

  public void doDamage(int damage)
  {
    if(invulnerable)return;
    StartCoroutine(handleIvunerable());
    vida -= damage;
    if (vida <= 0)
    {
      if(isBoss){
        GameObject.Find("spawnPoint").GetComponent<SpawPoint>().setBossWaveToZero();
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