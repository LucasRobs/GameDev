using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.U2D;

public class Entity : MonoBehaviour
{

  public float speed = 1f;
  public bool isBoss = false;
  public int level = 1;
  public GameObject player;
  public GameObject camera;
  public AiController AiController;
  public GameObject aStart;
  public GameObject soulPrefab;
  public GameObject foodPrefab;
  public AudioClip[] sounds;

  AudioSource audioSource;


  GameObject textDamege;
  Controller controller;
  GameObject spawner;
  SpawPoint spawPoint;
  bool invulnerable;

  Transform positionPlayer;
  float px;
  float py;
  SpriteRenderer spriteRender;

  int baseDamage = 1;
  int vida = 1;
  
  private void Start()
  {
    this.vida +=(int) level / 2;
    controller = camera.GetComponent<Controller>();
    spriteRender = GetComponent<SpriteRenderer>();
    positionPlayer = player.transform;
    audioSource = GetComponent<AudioSource>();
    audioSource.clip = sounds[Random.Range(0, sounds.Length)];
    textDamege = controller.getTextDamege();
    spawner = GameObject.Find("Spawner");
    spawPoint = spawner.GetComponent<SpawPoint>();
  }

  private void FixedUpdate()
  {
    if (positionPlayer.gameObject != null)
    {
      handleFlip();
      handleLayer();
      handlePosition();
    }
  }

    void handlePosition()
    {  
      if(spawPoint.needRelocation(aStart.transform)){
        aStart.transform.position = spawPoint.newSpawnPoint();
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
    print(vida);
    this.vida =(int) level / 2;
    print(vida);
  
    this.level = level;
  }

  public void setSpeed(float speed){
    this.speed = speed;
  }

  public void setCamera(GameObject _camera){
      camera = _camera;
  }

  public void setPlayer(GameObject _player){
      player = _player;
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
    showDamege(damage);
    StartCoroutine(handleIvunerable());
    vida -= damage;
    StartCoroutine(chanceColor());
    StartCoroutine(handleSpeed());
    showBlood();
    print(vida);
    if (vida <= 0)
    {
      handleSoul();
      toDie();
    }
  }

  void toDie(){
    if(isBoss){
      GameObject.Find("Spawner").GetComponent<SpawPoint>().setBossWaveToZero();
    }
    controller.addKill();
    spawPoint.removeEnemy(this.gameObject);
    audioSource.Play();
    AiController.DestroyNow();
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
      if(Random.Range(0,100) <= 2){
        GameObject food = Instantiate(foodPrefab, transform.position, Quaternion.identity);
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

    public void showDamege(int damage){
      GameObject textMP = Instantiate(textDamege, transform.position, Quaternion.identity);
      TextMeshPro TMP = textMP.GetComponent<TextMeshPro>();
      TMP.text = damage.ToString();
    }

    void showBlood(){
      Instantiate(controller.bloods[Random.Range(0, controller.bloods.Length)], transform.position, Quaternion.identity);
    }
}