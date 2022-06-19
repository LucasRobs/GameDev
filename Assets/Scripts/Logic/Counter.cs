using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 
public class Counter : MonoBehaviour
{
    public int kills = 0;
    public GameObject ui;
    TextMeshProUGUI TMPKill;
    private int level = 1;
    private int exp = 0;
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

    public float getVelocity(){
         if(level < 1)return 0.0010f;
        else if(level < 2)return 0.80f;
        else if(level < 3)return 0.70f;
        else if(level < 4)return 0.60f;
        else if(level < 5)return 0.50f;
        else if(level < 6)return 0.01f;
        else if(level < 7)return 0.30f;
        else if(kills < 120)return 0.20f;
        else if(kills < 150)return 0.10f;
        else if(kills < 200)return 0.09f;
        else if(kills < 300)return 0.08f;
        else if(kills < 400)return 0.07f;
        else if(kills < 500)return 0.06f;
        else if(kills < 1000)return 0.05f;
        else if(kills < 1500)return 0.20f;
        else if(kills < 2000)return 0.03f;
        else if(kills < 2500)return 0.02f;
        else if(kills < 3000)return 0.01f;
        else if(kills < 3100)return 0.5f;
        else if(kills < 3200)return 0.001f;
        else if(kills < 5000)return 0.00001f;
        return 0.0001f;
    }
}
