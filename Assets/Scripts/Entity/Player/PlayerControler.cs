using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
  public float speed = 2.5f;
  public Rigidbody2D PlayerRb;

  Vector2 movement;



  void Start()
  {
  }

  void Update()
  {
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");
  }

  private void FixedUpdate()
  {
    PlayerRb.MovePosition(PlayerRb.position + movement * speed * Time.fixedDeltaTime);
  }



}
