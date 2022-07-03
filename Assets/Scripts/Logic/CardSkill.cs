using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.U2D;
using UnityEngine.UI;

public class CardSkill : MonoBehaviour
{
    public Image spriteRender;
    public TextMeshProUGUI description;
    public TextMeshProUGUI name;

    public void setSkill(string _desc, string _name, Sprite _sprite)
    {
        spriteRender.sprite = _sprite;
        description.text = _desc+"";
        name.text = _name+"";
    }
}
