using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
  public string nome;
  public string descricao;
  public Sprite sprite;

  public string getNome(){
    return nome;
  }

  public string getDescricao(){
    return descricao;
  }

  public Sprite getSprite(){
    return sprite;
  }
}
