using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawPoint : MonoBehaviour{
    public GameObject enimy;
    public GameObject boss;
    public GameObject aStart;
    public GameObject bossAlert;
    public List<GameObject> enemys = new List<GameObject>();
    public Sprite spriteDefalt;
    
    GameObject camera;
    GameObject player;
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
    public Sprite[] spritesWave3_1;
    public Sprite[] spritesWave4;
    public Sprite[] spritesWave4_1;
    public Sprite[] spritesWave5;
    public Sprite[] spritesWave5_1;
    public Sprite[] spritesWave6;
    public Sprite[] spritesWave6_1;
    public Sprite[] spritesWave7;
    public Sprite[] spritesWave8;
    public Sprite[] spritesWave8_1;
    public Sprite[] spritesWave9;
    public Sprite[] spritesWave10;
    public Sprite[] spritesWave10_1;
    public Sprite[] spritesWave11;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.Find("Camera");
        controller = camera.GetComponent<Controller>();
        StartCoroutine(handleSpawn());
    }

    public void spawn(){
        if(bossWave == 0){
            spawnController += 1;
        }
        GameObject enimy = getNewEnimy();
        if(enimy){
            if(enemys.Count < 100){
                GameObject newAStart = Instantiate(aStart, newSpawnPoint(), Quaternion.Euler(0, 0, 0));
                GameObject newEnemy = Instantiate(enimy, newAStart.transform.position, Quaternion.Euler(0, 0, 0));
                newEnemy.transform.SetParent(newAStart.transform);
                newEnemy.GetComponent<Entity>().aStart = newAStart;
                enemys.Add(newEnemy);
            }
        }
    }

    public void removeEnemy(GameObject enemy){
        enemys.Remove(enemy);
    }

    float randonSignal(float number){
        return Random.Range(0, 2) == 1 ? number * -1 : number;
    }

    public Vector3 newSpawnPoint(){
        float x = randonSignal(player.transform.position.x + Random.Range(-9, 9));
        float y = randonSignal(player.transform.position.y + Random.Range(-9, 9));
        if(Random.Range(0, 2) == 1) x = player.transform.position.x + randonSignal(9f);
        else y = player.transform.position.y + randonSignal(9f);
        return new Vector3(x,y,0);
    }

    public bool needRelocation(Transform _transform){
        if(_transform){
            if((_transform.position.x > player.transform.position.x + 11 || _transform.position.y > player.transform.position.y + 11) || 
               (_transform.position.x < player.transform.position.x - 11 || _transform.position.y < player.transform.position.y - 11)){
                return true;
            }
        }
        return false;
    }
    
    public void setBossWaveToZero(){
        bossWave = 0;
    }

  
  IEnumerator startBossAlert()
  {
      for(int i = 0; i < 5; i++){
        bossAlert.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        bossAlert.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
      }
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
            StartCoroutine(startBossAlert());
        }else if(spawnController <= 115 * spawnMultiplier){//wave 2
            sprite = spritesWave2[Random.Range(0, spritesWave2.Length)];
            level = 2;
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
            StartCoroutine(startBossAlert());
        }else if(spawnController <= 300 * spawnMultiplier|| bossWave == 3 ){//wave 3
            sprite = spritesWave3[Random.Range(0, spritesWave3.Length)];
            level = 1;
        }else if(spawnController <= 301 * spawnMultiplier){//wave 3_1 BOSS
            sprite = spritesWave3[Random.Range(0, spritesWave3_1.Length)];
            level = 20;
            speed = 0.9f;
            isBoss = true;
            bossWave = 3;
            controller.setVelocity(1f);
            StartCoroutine(startBossAlert());
        }else if(spawnController <= 450 * spawnMultiplier || bossWave == 4){//wave 4
            sprite = spritesWave4[Random.Range(0, spritesWave4.Length)];
            level = 5;
            if(bossWave != 4) controller.setVelocity(0.5f);
        }else if(spawnController <= 451 * spawnMultiplier){//wave 4_1 BOSS
            sprite = spritesWave3[Random.Range(0, spritesWave4_1.Length)];
            level = 25;
            speed = 0.5f;
            isBoss = true;
            bossWave = 4;
            controller.setVelocity(1f);
            StartCoroutine(startBossAlert());
        }else if(spawnController <= 520 * spawnMultiplier || bossWave == 5){//wave 5
            sprite = spritesWave5[Random.Range(0, spritesWave5.Length)];
            level = 5;
            if(bossWave != 5) controller.setVelocity(0.5f);
        }else if(spawnController <= 521 * spawnMultiplier){//wave 5 BOSS
            sprite = spritesWave5_1[Random.Range(0, spritesWave5_1.Length)];
            level = 10;
            speed = 1.5f;
            isBoss = true;
            bossWave = 5;
            controller.setVelocity(0.4f);
            StartCoroutine(startBossAlert());
        }else if(spawnController <= 600 * spawnMultiplier || bossWave == 6){//wave 6
            sprite = spritesWave6[Random.Range(0, spritesWave6.Length)];
            level = 8;
            controller.setVelocity(0.5f);
        }else if(spawnController <= 601 * spawnMultiplier){//wave 6 BOSS
            sprite = spritesWave6_1[Random.Range(0, spritesWave6_1.Length)];
            level = 40;
            speed = 0.8f;
            isBoss = true;
            bossWave = 6;
            StartCoroutine(startBossAlert());
        }else if(spawnController <= 1000 * spawnMultiplier){//wave 7
            sprite = spritesWave7[Random.Range(0, spritesWave7.Length)];
            level = 10;
            controller.setVelocity(0.5f);
        }else if(spawnController <= 1500 * spawnMultiplier){//wave 8
            sprite = spritesWave8[Random.Range(0, spritesWave8.Length)];
            level = 8;
            controller.setVelocity(0.4f);
        }else if(spawnController <= 2000 * spawnMultiplier){//wave 8
            sprite = spritesWave8_1[Random.Range(0, spritesWave8_1.Length)];
            level = 8;
            controller.setVelocity(0.3f);
        }else if(spawnController <= 4000 * spawnMultiplier){//wave 9
            sprite = spritesWave9[Random.Range(0, spritesWave9.Length)];
            level = 9;
            controller.setVelocity(0.2f);
        }else if(spawnController <= 5500 * spawnMultiplier){//wave 10
            sprite = spritesWave10[Random.Range(0, spritesWave10.Length)];
            level = 10;
            controller.setVelocity(0.1f);
        }else if(spawnController <= 10000 * spawnMultiplier){//wave 10_1
            sprite = spritesWave10_1[Random.Range(0, spritesWave10_1.Length)];
            level = 20;
            controller.setVelocity(0.01f);
        }else if(spawnController <= 10001 * spawnMultiplier){//wave 11
            sprite = spritesWave11[Random.Range(0, spritesWave11.Length)];
            level = 100;
            speed = 2f;
            isBoss = true;
            bossWave = 10;
            StartCoroutine(startBossAlert());
        }else if(spawnController > 10001){//wave 12
            return null; 
        }

        GameObject newEnimy;
        
        if(isBoss) newEnimy = boss;
        else newEnimy = enimy;

        newEnimy.GetComponent<SpriteRenderer>().sprite = sprite;
        Entity newEtity = newEnimy.GetComponent<Entity>();
        newEtity.player= player;
        newEtity.camera= camera;
        newEtity.level = level;
        newEtity.speed = speed;
        if(isBoss){
            newEtity.setSpawPoint(this);
            newEtity.setIsBossToTrue();
        }
        return newEnimy;
    }

    IEnumerator handleSpawn()
    {  
        yield return new WaitForSeconds(controller.getVelocity());
        spawn();    
        StartCoroutine(handleSpawn());
    }
}
