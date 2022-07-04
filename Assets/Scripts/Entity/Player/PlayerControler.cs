using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
  public Rigidbody2D PlayerRb;
  public SpriteRenderer spriteRender;
  public GameObject lifeBar;


  Vector2 movement;
  bool ladoDireito = false;
  bool ladoSuperior = false;
  Vector2 lookingFor = new Vector2(0, 1);

  //staus
  int maxLife = 50;
  int life = 50;
  float baseDamege = 1;
  int maxProtection = 0;
  int protection = 0;
  float speed = 2.5f;
  bool isDead = false;
  bool withBlood = false;

  Controller controller;
  GameObject camera;

  void Start(){
    camera = GameObject.Find("Camera");
    controller = camera.GetComponent<Controller>();
  }

  void Update()
  {
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");
    if(movement.y != 0 || movement.x != 0){
      lookingFor = movement;
    }
    if (movement.x > 0 && !ladoDireito){// se o player estiver andando para a direita
		  vire ();
      lookingFor.x = 1;
    } 
		if (movement.x < 0 && ladoDireito){// se o player estiver andando para a esquerda
      vire ();
      lookingFor.x = -1;
    } 
    if (movement.y > 0){// se o player estiver andando para cima 
      lookingFor.y = 1;
    } 
    if (movement.y < 0){// se o player estiver andando para baixo
      lookingFor.y = -1;
    } 
  }

  private void FixedUpdate()
  {
    PlayerRb.MovePosition(PlayerRb.position + movement * speed * Time.fixedDeltaTime);
  }

	void vire(){
		ladoDireito = !ladoDireito;
    spriteRender.flipX = !spriteRender.flipX;
	}

  public Vector2 getLookingFor(){
    return lookingFor;
  }


  public void takesDamege(int index){
    this.life -= index;
    if(this.life <= 0){
      this.life = 0;
      isDead = true;
    }
    lifeBar.transform.localScale = new Vector3((float)life / (float)maxLife, 1, 1);
    StartCoroutine(changeColor());
    StartCoroutine(showBlood());
  }

    IEnumerator changeColor()
    {  
        spriteRender.color = new Color(255, 0, 0, 255);
        yield return new WaitForSeconds(0.3f);
        spriteRender.color = new Color(255, 255, 255, 255);
    }

    IEnumerator showBlood()
    { 
        if(!withBlood){
          withBlood = true;
          GameObject blood = Instantiate(controller.bloods[Random.Range(0, controller.bloods.Length)], transform.position, Quaternion.identity);
          yield return new WaitForSeconds(0.3f);
          withBlood = false;
        }
    }

  public void addMaxLife(int value){
    maxLife += value;
    life += value;
  }

  public void addSpeed(float value){
    speed += value;
  }

  public void addDamege(float value){
    baseDamege = value;
  }

  public void addMaxProtection(int value){
    maxProtection += value;
    protection += value;
  }
}
