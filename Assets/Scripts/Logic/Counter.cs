using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 
public class Counter : MonoBehaviour
{
    public int kills = 0;
    public GameObject ui;
    TextMeshProUGUI TMPKill;
    int level = 1;
    int exp = 0;
    float velocity = 1f;

   void Start()
    {
        TMPKill = ui.GetComponent<TextMeshProUGUI>();
        getLevel();
    }
    public void addKill(int _exp)
    {
        kills += 1;
        TMPKill.text = kills+"";
        handleLevel(_exp);
    }

    public void handleLevel(int _exp)
    {
        this.exp += _exp;
        if (this.exp >= getExpNextLevel())
        {
            level += 1;
            this.exp = 0;
        }
    }

    public int getExpNextLevel()
    {
        return ((int) ((level * 2f) * 10));
    }
    public int getLevel(){
        return level;
    }

    public void setVelocity(float velocity){
        this.velocity = velocity;
    }

    public float getVelocity(){
        return velocity;
    }
}
