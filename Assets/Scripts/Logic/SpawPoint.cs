using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawPoint : MonoBehaviour{
    public GameObject enimy;
    public GameObject boss;
    public List<GameObject> enemys = new List<GameObject>();
    public Sprite spriteDefalt;
    
    GameObject camera;
    Controller controller;
    int spawnController = 0;
    int spawnMultiplier = 1;
    int bossWave = 0;
    
    public Sprite[] spritesWave1;
    public Sprite[] spritesWave1_1;
    public Sprite[] spritesWave2;
    public Sprite[] spritesWave2_1;
    public Sprite[] spritesWave2_2;
    public Sprite[] spritesWave3;
    public Sprite[] spritesWave4;
    public Sprite[] spritesWave4_1;
    public Sprite[] spritesWave5;
    public Sprite[] spritesWave6;
    public Sprite[] spritesWave6_1;
    public Sprite[] spritesWave7;
    public Sprite[] spritesWave8;
    public Sprite[] spritesWave8_1;
    public Sprite[] spritesWave9;
    public Sprite[] spritesWave10;
    public Sprite[] spritesWave10_1;

    private void Start()
    {
        camera = GameObject.Find("Camera");
        controller = camera.GetComponent<Controller>();
    }

    public void spawn(){
        if(bossWave == 0){
            spawnController += 1;
        }
        GameObject newEnemy = Instantiate(getNewEnimy(), transform.position, Quaternion.Euler(0, 0, 0));
        enemys.Add(newEnemy);
    }

    public void setBossWaveToZero(){
        bossWave = 0;
    }

    private GameObject getNewEnimy(){
        Sprite sprite = spriteDefalt;
        int level = 1;
        float speed = 1f;
        bool isBoss = false;
        if(spawnController <= 50 * spawnMultiplier || bossWave == 1){ //wave 1
            sprite = spritesWave1[Random.Range(0, spritesWave1.Length)];
            level = 1;
            if(bossWave != 1) controller.setVelocity(2f);
        }else if(spawnController <= 51 * spawnMultiplier){//wave 1_1 BOSS
            sprite = spritesWave1_1[Random.Range(0, spritesWave1_1.Length)];
            level = 10;
            speed = 0.5f;
            isBoss = true;
            bossWave = 1;
            controller.setVelocity(1f);
        }else if(spawnController <= 115 * spawnMultiplier){//wave 2
            sprite = spritesWave2[Random.Range(0, spritesWave2.Length)];
            level = 2;
            controller.setVelocity(0.3f);
        }else if(spawnController <= 180 * spawnMultiplier || bossWave == 2 ){//wave 2_1
            sprite = spritesWave2_1[Random.Range(0, spritesWave2_1.Length)];
            level = 2;
            if(bossWave != 1) controller.setVelocity(0.5f);
        }else if(spawnController <= 181 * spawnMultiplier){//wave 2_2 BOSS
            sprite = spritesWave2_2[Random.Range(0, spritesWave2_2.Length)];
            level = 15;
            speed = 0.8f;
            isBoss = true;
            bossWave = 2;
            controller.setVelocity(1f);
        }else if(spawnController <= 300 * spawnMultiplier){//wave 3
            sprite = spritesWave3[Random.Range(0, spritesWave3.Length)];
            level = 1;
        }else if(spawnController <= 450 * spawnMultiplier){//wave 4
            sprite = spritesWave4[Random.Range(0, spritesWave4.Length)];
            level = 4;
        }else if(spawnController <= 520 * spawnMultiplier){//wave 5
            sprite = spritesWave5[Random.Range(0, spritesWave5.Length)];
            level = 5;
        }else if(spawnController <= 570 * spawnMultiplier){//wave 6
            sprite = spritesWave6[Random.Range(0, spritesWave6.Length)];
            level = 6;
        }else if(spawnController <= 600 * spawnMultiplier){//wave 6
            sprite = spritesWave6_1[Random.Range(0, spritesWave6_1.Length)];
            level = 6;
        }else if(spawnController <= 1000 * spawnMultiplier){//wave 7
            sprite = spritesWave7[Random.Range(0, spritesWave7.Length)];
            level = 7;
        }else if(spawnController <= 1500 * spawnMultiplier){//wave 8
            sprite = spritesWave8[Random.Range(0, spritesWave8.Length)];
            level = 8;
        }else if(spawnController <= 2000 * spawnMultiplier){//wave 8
            sprite = spritesWave8_1[Random.Range(0, spritesWave8_1.Length)];
            level = 8;
        }else if(spawnController <= 4000 * spawnMultiplier){//wave 9
            sprite = spritesWave9[Random.Range(0, spritesWave9.Length)];
            level = 9;
        }else if(spawnController <= 5500 * spawnMultiplier){//wave 10
            sprite = spritesWave10[Random.Range(0, spritesWave10.Length)];
            level = 10;
        }else if(spawnController <= 10000 * spawnMultiplier){//wave 10
            sprite = spritesWave10_1[Random.Range(0, spritesWave10_1.Length)];
            level = 10;
        }
        GameObject newEnimy;
        
        if(isBoss) newEnimy = boss;
        else newEnimy = enimy;

        newEnimy.GetComponent<SpriteRenderer>().sprite = sprite;
        newEnimy.GetComponent<Entity>().setLevel(level);
        newEnimy.GetComponent<Entity>().setSpeed(speed);
        if(isBoss){
            newEnimy.GetComponent<Entity>().setSpawPoint(this);
            newEnimy.GetComponent<Entity>().setIsBossToTrue();
        }
        return newEnimy;
    }
}
