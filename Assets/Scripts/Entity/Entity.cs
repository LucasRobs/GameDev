using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
  public int level = 1;
  public int vida;
  public float speed = 1f;
  public bool isBoss = false;
  public GameObject soulPrefab;
  public AudioClip[] sounds;
  private AudioSource audioSource;


  GameObject player;
  GameObject camera;

  Controller controller;
  bool invulnerable;

  Transform positionPlayer;
  SpawPoint spawPoint;
  SpriteRenderer spriteRender;

  int baseDamage = 1;
  
  private void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    camera = GameObject.Find("Camera");
    controller = camera.GetComponent<Controller>();
    spriteRender = GetComponent<SpriteRenderer>();
    positionPlayer = player.transform;
    audioSource = GetComponent<AudioSource>();
    audioSource.clip = sounds[Random.Range(0, sounds.Length)];
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
    StartCoroutine(chanceColor());
    StartCoroutine(handleSpeed());
    showBlood();

    if (vida <= 0)
    {
      handleSoul();
      toDie();
    }
  }

  void toDie(){
    if(isBoss){
      GameObject.Find("spawnPoint").GetComponent<SpawPoint>().setBossWaveToZero();
    }
    controller.addKill();
    audioSource.Play();
    Destroy(transform.gameObject,0.1f);
  }

  void handleSoul(){
    if(isBoss){
      GameObject soul = Instantiate(soulPrefab, transform.position, Quaternion.identity);
      soul.GetComponent<Soul>().init(level*5);
      print(level*5);
    }else{
      if(Random.Range(0,100) < 50){
        GameObject soul = Instantiate(soulPrefab, transform.position, Quaternion.identity);
        int force = Random.Range(1,3);
        if(Random.Range(0,100) < 5){force = force * 2;}
        soul.GetComponent<Soul>().init(force);
        print(force);
      }
    }
  }

  IEnumerator handleIvunerable()
    {  
        invulnerable = true;
        yield return new WaitForSeconds(0.5f);
        invulnerable = false;
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<PlayerControler>().takesDamege((int)(level/2)+baseDamage);
        }
    }

    IEnumerator chanceColor()
    {
        spriteRender.color = new Color(255, 0, 0, 255);
        yield return new WaitForSeconds(0.3f);
        spriteRender.color = new Color(1, 1, 1, 1);
    }

    IEnumerator handleSpeed(){
        float speedAux = speed;
        speed = speed / 3;
        yield return new WaitForSeconds(0.3f);
        speed = speedAux;
    }

    void showDamege(int damage){
        
    }

    void showBlood(){
      Instantiate(controller.bloods[Random.Range(0, controller.bloods.Length)], transform.position, Quaternion.identity);
    }
    
}