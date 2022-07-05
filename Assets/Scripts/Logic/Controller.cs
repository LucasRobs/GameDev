using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 
public class Controller : MonoBehaviour
{
    public int kills = 0;
    public GameObject ui;
    public Transform levelUpMenu;
    public GameObject[] Skills;
    public CardSkill[] CardsSkill = new CardSkill[3];
    public GameObject[] bloods;
    
    TextMeshProUGUI TMPKill;
    int level = 1;
    int exp = 0;
    float velocity = 1f;
    Spell[] skillsSelected = new Spell[3];
    ISpellControler[] skillsInChoice = new ISpellControler[3];
    bool inChoice = false;


   void Start()
    {
        TMPKill = ui.GetComponent<TextMeshProUGUI>();
        getLevel();
    }

    public void addKill()
    {
        kills += 1;
        TMPKill.text = kills+"";
    }



    public void handleLevel(int _exp)
    {
        this.exp += _exp;
        print(exp+"/"+ getExpNextLevel() +" level:"+ getLevel());
        if (this.exp >= getExpNextLevel())
        {
            while(this.exp >= getExpNextLevel())
            {
                if(!inChoice){
                    inChoice = true;
                    levelUp();
                }
            }
        }
    }

    void levelUp(){
        this.exp -= getExpNextLevel();
        level += 1;
        Time.timeScale = 0f;
        generateNewSkills();
        levelUpMenu.gameObject.SetActive(true);
    }

    public void addSkill(int index)
    {
        inChoice = true;
        Time.timeScale = 1f;
        levelUpMenu.gameObject.SetActive(false);
        skillsInChoice[index].addSkill();
    }

    void generateNewSkills(){
        int[] oudNunbers = new int[3];
        for (int i = 0; i < 3; i++){
            int index = Random.Range(0, Skills.Length);
            while(index == oudNunbers[0] || index == oudNunbers[1]){
                index = Random.Range(0, Skills.Length);
            }
            oudNunbers[i] = index;

            skillsSelected[i] = Skills[index].GetComponent<Spell>();
            skillsInChoice[i] = Skills[index].GetComponent<ISpellControler>();
            
            CardsSkill[i].setSkill(
                skillsSelected[i].getDescricao(), 
                skillsSelected[i].getNome(), 
                skillsSelected[i].getSprite()
            );
        }
    }

    public int getExpNextLevel()
    {
        float mutiplicador = level * 2f;
        return ((int) ((level * 0.1f) * mutiplicador));
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

    public void takeSoul(int index){
        //colocar efeitos da soul indo ate o player;
        handleLevel(index);
    }
}
